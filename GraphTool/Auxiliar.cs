using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Graphs;

namespace Auxiliar
{
    /************************************************************************************************************/
    public class Matrix // used for computing matrix operations
	{
		public long[,] m;   // the matrix; used as adjacency matrix for a graph
		public int dim;     // dimension of the matrix

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

		public Matrix(Graph graph)  // builds adjacency matrix from a graph
		{
			dim = graph.vertices.Count;
			m = new long[dim, dim];
			foreach (Edge e in graph.edges)
			{
				m[e.src.index, e.dst.index]++;
				if (!graph.oriented) m[e.dst.index, e.src.index]++;
			}
		}

        public Matrix(int size, bool is_unit)   // creates an empty or a unit matrix
		{
			dim = size;
			m = new long[dim, dim];
			if (is_unit) for (int i = 0; i < dim; i++) m[i, i] = 1;
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private Matrix multiply(Matrix matrix)  // multiplies with another matrix
		{
            try
            {
                checked
                {
                    Matrix result = new Matrix(matrix.dim, false);
                    for (int i = 0; i < dim; i++)
                        for (int j = 0; j < dim; j++)
                        {
                            long s = 0;
                            for (int k = 0; k < dim; k++) s += m[i, k] * matrix.m[k, j];
                            result.m[i, j] = s;
                        }
                    return result;
                }
            }
            catch (OverflowException e)
            {
                return null;
            }
		}

		public Matrix power(int exponent) // raises to power
		{
            try
            {
                if (exponent == 0) return new Matrix(dim, true);
                if (exponent == 1) return this;

                Matrix result = power(exponent / 2);
                return power(exponent % 2).multiply(result).multiply(result);   // genial ?!
            }
            catch (Exception e)
            {
                return null;
            }
		}

		private Matrix sum(Matrix matrix)    // sums up with another matrix
		{
            try
            {
                checked
                {
                    Matrix result = new Matrix(dim, false);
                    for (int i = 0; i < dim; i++)
                        for (int j = 0; j < dim; j++)
                            result.m[i, j] = m[i, j] + matrix.m[i, j];
                    return result;
                }
            }
            catch (OverflowException err)
            {
                return null;
            }
		}

		public Matrix powersum(StatusBarPanel sbp, int max_exponent)   // sums up powers of matrix while showing progress
		{
            try
            {
                Matrix result = new Matrix(dim, false);
                Matrix power_matrix = new Matrix(dim, true);
                for (int i = 1; i < max_exponent + 1; i++)
                {
                    sbp.Text = "Please wait. Computing power " + i + " ...";
                    power_matrix = power_matrix.multiply(this);
                    result = result.sum(power_matrix);
                }
                return result;
            }
            catch (Exception err)
            {
                return null;
            }
		}
	}
    /************************************************************************************************************/

    /************************************************************************************************************/
    public class Cell   // used in regular expression parsing tree
    {
        public String info;
        public int type;
        public Cell parent, left, right;

        public Cell() { }

        public Cell(String information, Cell father, Cell left_child, Cell right_child)
        {
            info = information;
            parent = father;
            left = left_child;
            right = right_child;
            type = AutomataBuilder.TYPE_UNPARSED_STRING;
            if (information.Equals("U")) type = AutomataBuilder.TYPE_UNION;
            if (information.Equals("+")) type = AutomataBuilder.TYPE_CONCAT;
            if (information.Equals("*")) type = AutomataBuilder.TYPE_STAR;
            if (information.Equals("(") || information.Equals(")")) type = AutomataBuilder.TYPE_BRACKET;
            if (information.IndexOfAny(new char[] { '*', '+', 'U', '(', ')' }) < 0) type = AutomataBuilder.TYPE_STRING;
        }
    }
    /************************************************************************************************************/

    /************************************************************************************************************/
    public class Tree   // used as operand & operator tree to analyse a regular expression
    {
        private String regex;           // the regular expression
        private ArrayList elements;     // atoms composing the expression

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public Tree(String regular_expression)  // creates the structural tree from a regular expression
        {
            regex = prepare(regular_expression, false);
            elements = new ArrayList();
            if (check(regex)) parse();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public String getExpression() { return regex; }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static String prepare(String expression, bool insert_spaces) // does preliminary string formatting
        {
            String result = expression.Replace(" ", "").Replace("()", "");
            if (!insert_spaces) return result;
            return result.Replace("U", " U ").Replace("*", "* ");
        }

        public static bool check(String expression)  // checks if parameter string is a valid regular expression
        {
            if (expression.Length < 1) return false;
            if ("*U)".IndexOf(expression[0]) >= 0) return false;
            if (expression[expression.Length - 1] == 'U') return false;
            if (expression.IndexOf("(*") >= 0) return false;
            if (expression.IndexOf("(U") >= 0) return false;
            if (expression.IndexOf("U)") >= 0) return false;
            if (expression.IndexOf("U*") >= 0) return false;
            if (expression.IndexOf("UU") >= 0) return false;
            if (expression.IndexOf("**") >= 0) return false;
            if (expression.Equals("*") || expression.Equals("U")) return false;

            int brackets = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (" abcdefghijklmnopqrstuvwxyz()*U".IndexOf(expression[i].ToString()) < 0) return false;
                if (expression[i] == '(') brackets++;
                if (expression[i] == ')') brackets--;
                if (brackets < 0) return false;
            }
            if (brackets != 0) return false;

            return true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void parse()    // parses regular expression into elements
        {
            int i = -1;
            while (i < regex.Length - 1)
            {
                i++;

                if ((regex[i] == '*' || regex[i] == ')') && i < (regex.Length - 1) && "abcdefghijklmnopqrstuvwxyz(".IndexOf(regex[i + 1].ToString()) >= 0)
                    regex = regex.Substring(0, i + 1) + "+" + regex.Substring(i + 1);
                
                if (i < (regex.Length - 1) && regex[i + 1].Equals('(') && "abcdefghijklmnopqrstuvwxyz".IndexOf(regex[i].ToString()) >= 0)
                    regex = regex.Substring(0, i + 1) + "+" + regex.Substring(i + 1);

                if ("()*U+".IndexOf(regex[i].ToString()) >= 0)
                    elements.Add(regex[i].ToString());
                else
                {
                    int j = i;
                    while (i < (regex.Length - 1) && "()*+U".IndexOf(regex[i + 1].ToString()) < 0) i++;
                    elements.Add(regex.Substring(j, i - j + 1));
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private int priority(char character)    // returns priority for an operator
        {
            if (character == '(' || character == ')') return 0;
            if (character == 'U') return 1;
            if (character == '+') return 2;
            if (character == '*') return 3;
            return -1000;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public Cell getRoot()   // builds regular expression tree and returns root
        {
            String[] operators = new String[1000];  // operator stack
            int top2 = 1;                           // operator stack top
            Cell[] operands = new Cell[1000];       // operand stack
            int top1 = 0;                           // operand stack top
            
            operators[top2] = "(";
            elements.Add(")");

            foreach (String element in elements)
            {
                if ("()*U+".IndexOf(element[0].ToString()) < 0)
                    operands[++top1] = new Cell(element, null, null, null);
                else
                {
                    if (element[0] == '(')
                        operators[++top2] = "(";
                    else
                    {
                        while (top2 > 0 && operators[top2][0] != '(' && operators[top2][0] != ')'
                            && priority(operators[top2][0]) >= priority(element[0]))
                        {
                            if (operators[top2][0] == '*')
                                operands[top1] = new Cell(operators[top2], null, operands[top1], null);
                            else
                            {
                                operands[top1 - 1] = new Cell(operators[top2], null, operands[top1 - 1], operands[top1]);
                                top1--;
                            }
                            top2--;
                        }
                        if (top2 > 0)
                            if (operators[top2][0] != '(' || element[0] != ')')
                                operators[++top2] = element;
                            else
                                top2--;
                    }
                }
                if (top2 <= 0) break;
            }
            
            if (top2 == 0) return operands[1];

            MessageBox.Show("Parsing error!", "*** Output error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
    /************************************************************************************************************/

    /************************************************************************************************************/
	public class AutomataBuilder    // builds non-deterministic and deterministic automata
	{
        public const int TYPE_UNPARSED_STRING = -2;
        public const int TYPE_STRING = -1;
        public const int TYPE_BRACKET = 0;
        public const int TYPE_UNION = 1;
        public const int TYPE_CONCAT = 2;
        public const int TYPE_STAR = 3;
 
        private static Graph graph;         // used for automaton building
        private static Graph aux;           // used as auxiliary graph
        
        private static List<Vertex> EofQ;   // used in conversion algorithm

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private AutomataBuilder() { }   // cannot be instantiated

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Graph getNondeterministicAutomaton(String accepted_language, int width, int height)
        {
            Tree tree = new Tree(accepted_language);
            graph = new Graph("NonDeterm", true);
            Vertex start = new Vertex(0, 0, "");
            Vertex finish = new Vertex(0, 0, "");
            start.is_start = true;
            finish.is_finish = true;
            graph.addV(start);
            graph.addV(finish);
            makeNonDeterministic(tree.getRoot(), start, finish);
            graph.arrangeCircle(width, height);
            return graph;
        }

        private static void makeNonDeterministic(Cell current_cell, Vertex v1, Vertex v2)  // builds nondeterministic automaton recursively
        {
            switch (current_cell.type)
            {
                case TYPE_STRING:
                    graph.addEfast(new Edge(v1, v2, current_cell.info));
                    break;
                case TYPE_CONCAT:
                    Vertex v = new Vertex(0, 0, "");
                    graph.addV(v);
                    makeNonDeterministic(current_cell.left, v1, v);
                    makeNonDeterministic(current_cell.right, v, v2);
                    break;
                case TYPE_UNION:
                    makeNonDeterministic(current_cell.left, v1, v2);
                    makeNonDeterministic(current_cell.right, v1, v2);
                    break;
                case TYPE_STAR:
                    if (v1 == v2)
                        makeNonDeterministic(current_cell.left, v1, v2); // current_cell.right = "e"
                    else
                    {
                        Vertex u = new Vertex(0, 0, "");
                        graph.addV(u);
                        graph.addEfast(new Edge(v1, u, "e"));
                        graph.addEfast(new Edge(u, v2, "e"));
                        makeNonDeterministic(current_cell.left, u, u); // current_cell.right = "e"
                    }
                    break;
                default:
                    break;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Graph getDeterministicAutomaton(Graph nondeterministic, int width, int height)    // really slow. 2b optimized
        {
            aux = new Graph(nondeterministic, Graph.CLONE_ORIGINAL);
            insertAuxPoints();
            aux.computeAlphabet();
            
			graph = new Graph("Determ", true);

            List<List<Vertex>> states = new List<List<Vertex>>();
			List<Vertex> current = new List<Vertex>();
			List<Vertex> finish = new List<Vertex>();
	
			foreach (Vertex v in aux.vertices)
			{
				if (v.is_start)
				{
					current = getEofQ(v);
					states.Add(current);
				}
				if (v.is_finish)
					finish.Add(v);
			}
			
			Vertex start = new Vertex(0, 0, "");
			start.is_start = true;
			graph.addV(start);

            int ind = 0;
            while (ind < states.Count)
			{
                //Console.WriteLine("ind = " + ind + "  count = " + states.Count);
                current = states[ind];
				for (int i = 2; i < aux.alphabet.Length; i += 2)
				{
					List<Vertex> qs = getSigma(current, aux.alphabet[i].ToString());
					List<Vertex> reunion = new List<Vertex>();
					foreach (Vertex v in qs)
						reunion = concat(reunion, getEofQ(v));
					int rez = contains(states, reunion);
					Vertex src = (Vertex) graph.vertices[ind];
					Vertex dst;
					if (rez < 0)
					{
						states.Add(reunion);
						dst = new Vertex(0, 0, (reunion.Count == 0) ? "Null" : "");
						graph.addV(dst);
					}
					else
					{
						dst = (Vertex) graph.vertices[rez];
					}
					graph.addEfast(new Edge(src, dst, aux.alphabet[i].ToString()));
				}
				ind++;
			}
			
			foreach (Vertex v in finish)
			{
				for (int i = 0; i < states.Count; i++)
				{
					if (states[i].Contains(v))
						((Vertex)graph.vertices[i]).is_finish = true;
				}
			}

            graph.arrangeCircle(width, height);
            return graph;
        }

        private static void insertAuxPoints()  // inserts auxiliary points into nondeterministic automaton
        {
            int max = aux.edges.Count;  // number of edges will increase
            
            for (int i = 0; i < max; i++)
            {
                Edge e = (Edge) aux.edges[i];
                char[] ch = e.name.ToCharArray();
                Vertex temp_src = e.src;
                for (int j = 0; j < ch.Length - 1; j++)
                {
                    Vertex v = new Vertex(0, 0, "");
                    aux.addV(v);
                    aux.addEfast(new Edge(temp_src, v, ch[j].ToString()));
                    temp_src = v;
                }
                e.src.edges.Remove(e);
                e.dst.edges.Remove(e);
                e.src = temp_src;
                e.src.edges.Add(e);
                if (e.src != e.dst) e.dst.edges.Add(e);
                e.name = e.name.Substring(e.name.Length - 1);
            }
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private static bool equal<T>(List<T> al1, List<T> al2) // checks if two lists are contained in one another
		{
			foreach (T ob in al1)
				if ( !al2.Contains(ob) ) return false;
			foreach (T ob in al2)
				if ( !al1.Contains(ob) ) return false;
			return true;
		}

		private static int contains<T>(List<List<T>> where, List<T> what) // checks if a list of lists contains a list
		{
			foreach (List<T> list in where)
				if (equal(list, what)) return where.IndexOf(list);
			return -1;
		}

		private static List<T> concat<T>(List<T> al1, List<T> al2)   // concatenates two lists
		{
			foreach (T ob in al2)
				if (!al1.Contains(ob)) al1.Add(ob);
			return al1;
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private static void explore(Vertex v)   // explores automaton from a vertex passing only through empty string tranzitions
		{
			EofQ.Add(v);
			foreach (Edge e in v.edges)
			{
				if (e.name != null)
					if (e.src == v && e.name.Equals("e") && EofQ.IndexOf(e.dst) < 0)
						explore(e.dst);
			}
		}

        private static List<Vertex> getEofQ(Vertex v)   // gets e-closure of a vertex
		{
            EofQ = new List<Vertex>();
			explore(v);
			return EofQ;
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private static List<Vertex> getSigma(IEnumerable<Vertex> state, String letter)    // gets next state after a tranzition
		{
            List<Vertex> result = new List<Vertex>();
			foreach (Vertex v in state)
			{
				foreach (Edge e in v.edges)
				{
					if (e.name != null)
						if (e.src == v && e.name.Equals(letter) && result.IndexOf(e.dst) < 0)
							result.Add(e.dst);
				}
			}
			return result;
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Graph getMinimalAutomaton(Graph deterministic, int width, int height)
        {
            graph = deterministic;
            graph.computeAlphabet();
            
            finals = new HashSet<int>();
            pairset = new HashSet<VertexPair>();
            foreach (Vertex v in graph.vertices)
                if (v.is_finish)
                    finals.Add(v.index);
            
            sigma = (p, a) =>
                {
                    Vertex v = (Vertex) graph.vertices[p];
                    int rez = -1;
                    foreach (Edge e in v.edges)
                    {
                        if (e.src == v && e.name[0] == a)
                        {
                            rez = e.dst.index;
                            break;
                        }
                    }
                    return rez;
                };
            sigma = Memoizer.Memoize2arg(sigma);
            
            equiv = (p, q, k) =>
                {
                    if (p == q) return true;
                    bool contains_p = finals.Contains(p);
                    bool contains_q = finals.Contains(q);
                    bool eq = (contains_p && contains_q) || (!contains_p && !contains_q);
                    if (k == 0)
                    {
                        return eq;
                    }
                    else
                    {
                        VertexPair pair = new VertexPair(p, q);
                        if (pairset.Contains(pair))
                        {
                            return true;
                        }
                        else
                        {
                            pairset.Add(pair);
                            for (int i = 2; i < graph.alphabet.Length; i += 2)
                            {
                                if (!eq) return false;
                                eq = eq && equiv(sigma(p, graph.alphabet[i]), sigma(q, graph.alphabet[i]), k - 1);
                            }
                            pairset.Remove(pair);
                        }
                    }
                    return eq;
                };
            equiv = Memoizer.Memoize3arg(equiv);

            int depth = graph.vertices.Count - 2;
            if (depth < 0) depth = 0;

            bool[,] equivalent = new bool[graph.vertices.Count, graph.vertices.Count];

            for (int v1 = 0; v1 < graph.vertices.Count; v1++)
                for (int v2 = 0; v2 < v1; v2++)
                    equivalent[v1, v2] = equivalent[v2, v1] = equiv(v1, v2, depth);

            DisjointSet eqclasses = new DisjointSet(graph.vertices.Count);
            for (int i = 0; i < graph.vertices.Count; i++) eqclasses.MakeSet(i);
            for (int v1 = 0; v1 < graph.vertices.Count; v1++)
                for (int v2 = 0; v2 < v1; v2++)
                    if (equivalent[v1, v2])
                        eqclasses.Union(v1, v2);

            HashSet<int> statesHash = new HashSet<int>();
            for (int i = 0; i < graph.vertices.Count; i++)
            {
                int repres = eqclasses.Find(i);
                ((Vertex)graph.vertices[i]).repres = repres;
                statesHash.Add(repres);
            }
            List<int> states = statesHash.ToList<int>();

            Graph minimal = new Graph("Minimal", true);
            for (int i = 0; i < states.Count; i++) minimal.addV(new Vertex(0, 0, ""));

            foreach (Edge e in graph.edges)
            {
                Vertex src = (Vertex)minimal.vertices[states.IndexOf(e.src.repres)];
                Vertex dst = (Vertex)minimal.vertices[states.IndexOf(e.dst.repres)];
                minimal.addEfastIfNotExist(new Edge(src, dst, e.name));
            }

            foreach (Vertex v in graph.vertices)
            {
                if (v.is_start) ((Vertex)minimal.vertices[states.IndexOf(v.repres)]).is_start = true;
                if (v.is_finish) ((Vertex)minimal.vertices[states.IndexOf(v.repres)]).is_finish = true;
            }

            foreach (Vertex v in minimal.vertices)
            {
                bool isNull = true;
                foreach (Edge e in v.edges)
                    if (e.dst != v)
                    {
                        isNull = false;
                        break;
                    }
                if (isNull) v.name = "Null";
            }

            minimal.arrangeCircle(width, height);
            return minimal;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static Func<int, char, int> sigma = null;
        private static Func<int, int, int, bool> equiv = null;
        private static HashSet<int> finals = null;
        private static HashSet<VertexPair> pairset = null;
        
        private class VertexPair : IEquatable<VertexPair>
        {
            public readonly int p;
            public readonly int q;

            public VertexPair(int p, int q)
            {
                this.p = p;
                this.q = q;
            }

            public bool Equals(VertexPair other)
            {
                return (p == other.p && q == other.q) || (p == other.q && q == other.p);
            }
        }
	}
    /************************************************************************************************************/

    /************************************************************************************************************/
    public class GraphFloater   // floats a graph on a picturebox
    {
        public const int LENGTH = 100;          // default edge target length
        public const float K = 0.3f;            // default elasticity constant (F = k * dl)
        public const int DELAY = 100;           // default delay between computations
        public const int MAX_MOVE = 5;          // maximum distance a vertex can be moved at each step
        
        public static int length = LENGTH;      // current edge target length
        public static float k = K;              // current elasticity constant
        public static int delay = DELAY;        // current delay

        private PictureBox pictureBox;          // picture box on which graph is drawn
        private Graph graph;                    // the floating graph
        private bool floating;                  // floating flag
        private bool scrambling;                // scrambling requested flag

        private BackgroundWorker worker;        // computations are done in another thread
        private Random rnd = new Random();      // random number generator
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void refresh(object sender, RunWorkerCompletedEventArgs args)   // done after computations
        {
            pictureBox.Refresh();   // can't access it in inc() because pictureBox was created in another thread
            if (floating)
                worker.RunWorkerAsync();  // redo computations
            else
                worker.Dispose();
        }

        private void inc(object sender, DoWorkEventArgs args)  // performs vertex positioning computations
        {
            try
            {
                Thread.Sleep(delay);

                int max_length = (pictureBox.Width < pictureBox.Height) ? pictureBox.Width : pictureBox.Height;
                max_length /= 3;    // maximum distance vertices influence eachother
                max_length = (max_length < 3 * length) ? max_length : 3 * length;

                lock (graph)    // to prevent the error below
                {
                    foreach (Edge e in graph.edges) // edges influence vertex position by number and length
                    {
                        if (e.src == e.dst) continue;

                        double vx = e.dst.pos.X - e.src.pos.X;
                        double vy = e.dst.pos.Y - e.src.pos.Y;
                        double len = Math.Sqrt(vx * vx + vy * vy);
                        len = (len == 0) ? .0001 : len;
                        int nre = graph.getEdges(e.src, e.dst).Count;
                        double f = (Math.Pow(nre, .3) * length - len) / len * k;
                        double dx = f * vx / nre;
                        double dy = f * vy / nre;

                        e.dst.dx += dx;
                        e.dst.dy += dy;
                        e.src.dx += -dx;
                        e.src.dy += -dy;
                    }

                    foreach (Vertex v in graph.vertices) // vertices influence eachother by distance
                    {
                        double dx = 0;
                        double dy = 0;

                        foreach (Vertex u in graph.vertices)
                        {
                            if (v == u) continue;

                            double vx = v.pos.X - u.pos.X;
                            double vy = v.pos.Y - u.pos.Y;
                            double len = vx * vx + vy * vy;
                            if (len == 0)
                            {
                                dx += rnd.NextDouble();
                                dy += rnd.NextDouble();
                            }
                            else if (len < max_length * max_length)
                            {
                                dx += vx / len;
                                dy += vy / len;
                            }
                        }

                        double dlen = dx * dx + dy * dy;
                        if (dlen > 0)
                        {
                            dlen = Math.Sqrt(dlen) / 2;
                            v.dx += dx / dlen;
                            v.dy += dy / dlen;
                        }
                    }

                    foreach (Vertex v in graph.vertices) // set new position
                    {
                        if (!v.selected)
                        {
                            v.pos.X += (float)Math.Max(-MAX_MOVE, Math.Min(MAX_MOVE, v.dx));
                            v.pos.Y += (float)Math.Max(-MAX_MOVE, Math.Min(MAX_MOVE, v.dy));
                            if (scrambling)
                            {
                                v.pos.X += (float)rnd.NextDouble() * length * 1.2f - length * 0.6f;
                                v.pos.Y += (float)rnd.NextDouble() * length * 1.2f - length * 0.6f;
                            }
                        }
                        if (v.pos.X > pictureBox.Width - MAX_MOVE * 2) v.pos.X = pictureBox.Width - MAX_MOVE * 2;
                        if (v.pos.X < MAX_MOVE * 2) v.pos.X = MAX_MOVE * 2;
                        if (v.pos.Y > pictureBox.Height - MAX_MOVE * 2) v.pos.Y = pictureBox.Height - MAX_MOVE * 2;
                        if (v.pos.Y < MAX_MOVE * 2) v.pos.Y = MAX_MOVE * 2;
                        v.dx /= 2;
                        v.dy /= 2;
                    }

                    scrambling = false;
                    graph.setAllPoints();
                }
            }
            catch (Exception err)   // sometimes we get an error saying that the vertices/edges collectons was modified
            {
                MessageBox.Show("Don't worry! \nThere is no sugar! \n\n" + err.ToString(), "*** Threading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
          
        public GraphFloater(PictureBox pictureBox, Graph graph)
        {
            this.pictureBox = pictureBox;
            this.graph = graph;
            foreach (Vertex v in graph.vertices) v.dx = v.dy = 0;
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(this.inc);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.refresh);
            floating = scrambling = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public void start() // starts the floating process
        {
            floating = true;
            worker.RunWorkerAsync();
        }

        public void stop()  // stops the floating process
        {
            floating = false;
        }

        public void scramble()  // sets a random position for each vertex
        {
            scrambling = true;
        }
    }
    /************************************************************************************************************/

    /************************************************************************************************************/
    public class MyQueue    // standard queue structure used in BFS & related algorithms
    {
        private Object[] objects;
        private int first, last;

        public MyQueue(int size)
        {
            objects = new Object[size];
            first = last = 0;
        }

        public bool isEmpty()
        {
            return (first == last);
        }

        public void add(Object obj)
        {
            objects[last++] = obj;	// no IndexOutOfBounds protection..
        }

        public Object remove()
        {
            return isEmpty() ? null : objects[first++];
        }
    }
    /************************************************************************************************************/

    /************************************************************************************************************/
    public class DisjointSet    // optimized disjoint-set data structure
    {
        private int[] parent;
        private int[] rank;

        public DisjointSet(int size)
        {
            parent = new int[size];
            rank = new int[size];
        }

        public void MakeSet(int x)
        {
            parent[x] = x;
            rank[x] = 0;
        }

        public int Find(int x)	// optimized with path-compression
        {
            if (parent[x] == x)
            {
                return x;
            }
            else
            {
                parent[x] = Find(parent[x]);
                return parent[x];
            }
        }

        public void Union(int x, int y)	// optimized with union-by-rank
        {
            int xRoot = Find(x);
            int yRoot = Find(y);

            if (rank[xRoot] > rank[yRoot]) parent[yRoot] = xRoot;
            if (rank[xRoot] < rank[yRoot]) parent[xRoot] = yRoot;
            if (rank[xRoot] == rank[yRoot] && xRoot != yRoot)
            {
                parent[yRoot] = xRoot;
                rank[xRoot]++;
            }
        }
    }
    /************************************************************************************************************/

    /************************************************************************************************************/
    public class MyPriorityQueue    // priority queue implemented as an array
    {
        private int[] in_queue;
        private ArrayList list;
        private int size;

        public MyPriorityQueue(ArrayList items)
        {
            list = items;
            size = items.Count;
            in_queue = new int[size];
        }

        public Object Poll()    // list must not be modified while using this queue
        {
            int index = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (in_queue[i] != 0) continue;
                if (index == -1 || ((IComparable)list[index]).CompareTo(list[i]) > 0) index = i;
            }
            if (index != -1)
            {
                in_queue[index] = 1;
                size--;
                return list[index];
            }
            return null;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
    }
    /************************************************************************************************************/

    /************************************************************************************************************/
    public static class Memoizer // provides extension methods for automatic function memoization
    {
        /*
          * AUTOMATIC MEMOIZATION
          * 
          * http://blogs.msdn.com/wesdyer/archive/2007/01/26/function-memoization.aspx
          * http://blogs.msdn.com/wesdyer/archive/2007/02/05/memoization-and-anonymous-recursion.aspx
          * http://blogs.msdn.com/wesdyer/archive/2007/02/11/baby-names-nameless-keys-and-mumbling.aspx
          * http://stackoverflow.com/questions/633508/two-argument-memoization
          * 
          */

        public static Func<A, B, C, R> Memoize3arg<A, B, C, R>(this Func<A, B, C, R> f)
        {
            var map = DictionaryHelper<R>.Create(new { a = default(A), b = default(B), c = default(C) });
            return (a, b, c) =>
            {
                var tuple = new { a, b, c };
                R value;
                if (map.TryGetValue(tuple, out value))
                    return value;
                value = f(a, b, c);
                map.Add(tuple, value);
                return value;
            };
        }

        public static Func<A, B, R> Memoize2arg<A, B, R>(this Func<A, B, R> f)
        {
            var map = DictionaryHelper<R>.Create(new { a = default(A), b = default(B) });
            return (a, b) =>
            {
                var tuple = new { a, b };
                R value;
                if (map.TryGetValue(tuple, out value))
                    return value;
                value = f(a, b);
                map.Add(tuple, value);
                return value;
            };
        }       
        
        private static class DictionaryHelper<Value>
        {
            public static Dictionary<Key, Value> Create<Key>(Key prototype)
            {
                return new Dictionary<Key, Value>();
            }
        }
    }
}
