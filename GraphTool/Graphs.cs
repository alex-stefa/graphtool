using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Auxiliar;

namespace Graphs
{
	/************************************************************************************************************/
    public class Vertex : IComparable
	{
        public const int BLACK = 0;
        public const int GRAY  = 1;
        public const int WHITE = 2;
                
        public int index;       // 0-based vertex index
        public String name;     // name to be displayed as info
        public String tech_name;// name to be displayed as info during special algorithms

        public ArrayList edges; // adjacent edges; same list for inwards and outwards edges
		
        public PointF pos;      // position on picturebox
        public double dx, dy;   // force acting on vertex in floating mode        
        public bool selected;   // if vertex is selected either in multiple or single select mode
		
        public bool is_start;   // if is a start vertex in an automaton
        public bool is_finish;  // if is a finish vertex in an automaton

        public int color;       // vertex color used in search algorithms
        public int start;       // stack add time; used in DFS algorithm
        public int finish;      // stack remove time; used in DFS algorithm
        public int component;   // 1-based (strongly) connected component index
        public double cost;     // cost of reaching vertex in weighted graph
        public int distance;    // distance to source in single-source search algorithms
        public Vertex parentV;  // parent of vertex in search algorithms
        public Edge parentE;    // edge linking parent to vertex in search algorithms
        public int repres;      // representative for a Disjoint-Set structure used in Kruskal & related algorithms
        public int cluster;     // 1-based cluster index in K-clustering algorithm 

        public Vertex(float x, float y, String n) 
		{
			pos = new PointF(x, y);
			name = n;
            edges = new ArrayList();
			is_start = is_finish = selected = false;
			index = component = repres = cluster = -1;
            color = Vertex.WHITE;
            start = finish = distance = 0;
            cost = double.MaxValue;
            parentV = null;
            parentE = null;
            tech_name = "";
		}

        public int CompareTo(object obj)
        {
            return cost.CompareTo(((Vertex)obj).cost);
        }
    }
    /************************************************************************************************************/

    /************************************************************************************************************/
    public class Edge : IComparable
	{
        public static Color TREE = Color.Red;
        public static Color BACK = Color.DarkViolet;
        public static Color FORWARD = Color.Green;
        public static Color CROSS = Color.FromArgb(1, 1, 1);
        
        public Vertex src;      // source vertex
        public Vertex dst;      // destination vertex
		public String name;     // text to be displayed as info (either letters, weight or just plain text)
        
        public double weight;   // edge weight for best path algorithms
		
        public int id;          // edge identifier in case of more than one edges between same vertices
		public PointF p1, p2;   // control points for Bezier curve
        public Color color;     // color in which edge is drawn on picturebox
        public Color tech_color;// color in which edge is drawn on picturebox during special algorithms

		public Edge(Vertex source, Vertex destination, String info)
		{
			src = source;
			dst = destination;
			name = info;
			color = Color.Black;
            weight = 0;
		}

		public PointF EvalBezier(float u)
		{
			float a1 = (1 - u) * (1 - u) * (1 - u);
			float a2 = 3 * u * (1 - u) * (1 - u);
			float a3 = 3 * u * u * (1 - u);
			float a4 = u * u * u;

			float x = a1 * src.pos.X + a2 * p1.X + a3 * p2.X + a4 * dst.pos.X;
			float y = a1 * src.pos.Y + a2 * p1.Y + a3 * p2.Y + a4 * dst.pos.Y;
			return new PointF(x, y);
		}

		public double getDist(PointF pt)
		{
			float u = 0.5f;

			for (int i = 0; i<4; i++)
			{
				double st = u - 1/Math.Pow(10,i)/2;
				double dr = u + 1/Math.Pow(10,i)/2;
				double dmin= 10000;
				if (st<0) st=0;
				if (dr>1) dr=1;
				for (int j = 0; j<11; j++)
				{
					double dcur = Graph.dist( EvalBezier( (float) (st + j*(dr-st)/10)), pt);
					if ( dcur < dmin )
					{
						dmin = dcur;
						u = (float) (st + j*(dr-st)/10);
					}
				}
			}

            PointF rez = EvalBezier(u);
			
            if ((Graph.dist(rez,src.pos) < 9)||(Graph.dist(rez,dst.pos) < 9))
				return 100;
			else 
				return Graph.dist(rez,pt);
		}

        public int CompareTo(object obj)
        {
            return weight.CompareTo(((Edge)obj).weight);
        }
    }
    /************************************************************************************************************/

    /************************************************************************************************************/
    public class Graph
	{
        public const int ARRANGE_GRID = 0;          // arrange vertices on a grid
        public const int ARRANGE_CIRCLE = 1;        // arrange vertices on a circle
        public const int TYPE_1GRAPH = 2;           // create a nonoriented 1-graph 
        public const int TYPE_PGRAPH = 3;           // create a nonoriented 5-graph
        public const int TYPE_COMPLETE = 4;         // create a complete nonoriented graph
        public const int CLONE_ORIGINAL = 5;        // clone the graph
        public const int CLONE_1GRAPH = 6;          // clone the oriented graph and make it nonoriented and delete multiple edges
        public const int CLONE_PGRAPH = 7;          // clone the oriented graph and make it nonoriented
        public const int CLONE_RANDOM = 8;          // clone the nonoriented graph and make it oriented randomly
        public const int CLONE_DOUBLE = 9;          // clone the nonoriented graph and make it oriented by doubling edges
        public const int CLONE_INFO = 10;           // clone the graph and write random info on edges
        public const int CLONE_ORIENTED = 11;       // clone the automaton and make it an oriented graph
        public const int CLONE_VERTICES = 12;       // clone vertices only

        public ArrayList vertices;
		public ArrayList edges;

		public String name;
		public String filename;
		
        public bool oriented;                       // if graph is oriented
        public String alphabet;                     // alphabet of the form "e [letter]*"
        
        public int components;                      // number of (strongly) connected components
        private ArrayList finished;                 // stores vertices in the order they finishe DFS
        private int time;                           // counter for DFS
        private int depth;                          // counter for DFS

        public int clusters;                        // number of clusters in the maximum spacing K-clustering algorithms
        public double spacing;                      // the minimum spacing between clusters
        public double total_spacing;                // the total minimum spacing between clusters

        public static int par1 = 11, par2 = 22;     // parameters that control multiple edge display
        
		/////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Graph(String graphName, bool orientation)    // creates an empty graph of a given orientation
		{
			vertices = new ArrayList();
			edges = new ArrayList();
			name = graphName;
			oriented = orientation;
            filename = alphabet = null;
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

		public void addV(Vertex v)  // adds a vertex to graph
		{
            v.index = vertices.Count;
			vertices.Add(v);
		}

		public void delV(Vertex v)  // removes a vertex from graph
		{
			ArrayList new_edges = new ArrayList(edges.Count);
			foreach (Edge e in edges)
				if (e.src != v && e.dst != v) new_edges.Add(e);
			edges = new_edges;
			
            vertices.RemoveAt(v.index);
            for (int i = v.index; i < vertices.Count; i++) ((Vertex)vertices[i]).index = i;

            foreach (Vertex u in vertices)
            {
                ArrayList new_u_edges = new ArrayList(u.edges.Count);
                foreach (Edge e in u.edges)
                    if (e.src != v && e.dst != v) new_u_edges.Add(e);
                u.edges = new_u_edges;
            }
		}

        public void addE(Edge e)    // adds an edge to graph
		{
			edges.Add(e);
            e.src.edges.Add(e);
            if (e.src != e.dst) e.dst.edges.Add(e);
			setAllPoints();
		}

		public void delE(Edge e)    // removes an edge from graph
		{
			edges.Remove(e);
            e.src.edges.Remove(e);
            e.dst.edges.Remove(e);
			setAllPoints();
		}

        public void addEfast(Edge e)    // same as addE() without calling setAllPoints()
        {
            edges.Add(e);
            e.src.edges.Add(e);
            if (e.src != e.dst) e.dst.edges.Add(e);
        }

        public bool addEfastIfNotExist(Edge e)  // checks before doubling edges
        {
            bool found = false;
            foreach (Edge edge in e.src.edges)
                if (edge.src == e.src && edge.dst == e.dst && edge.name.Equals(e.name))
                {
                    found = true;
                    break;
                }
            if (!found) addEfast(e);
            return found;
        }

        public void delEfast(Edge e)    // same as delE() without calling setAllPoints()
        {
            edges.Remove(e);
            e.src.edges.Remove(e);
            e.dst.edges.Remove(e);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public ArrayList getEdges(Vertex v1, Vertex v2) // returns edges between two vertices
		{
			ArrayList list = (v1.edges.Count < v2.edges.Count) ? v1.edges : v2.edges;
            ArrayList rez = new ArrayList(list.Count);
            foreach (Edge e in list)
				if ((e.src == v1 && e.dst == v2) || (e.src == v2 && e.dst == v1)) rez.Add(e);
			return rez;
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public void setPoints(ArrayList list)   // computes control points for bezier curves for edges in list
		{
			if (list.Count == 0) return;
			
            Edge te = (Edge) list[0];   // test edge to see if edges in list are between two vertices or loops
			
            if (te.src != te.dst)   // edges are between two distinct vertices
			{
				float m = te.dst.pos.X - te.src.pos.X;
				float n = te.dst.pos.Y - te.src.pos.Y;
				PointF C = new PointF(  m/3 + te.src.pos.X , n/3 + te.src.pos.Y );
				PointF D = new PointF(  2*m/3 + te.src.pos.X , 2*n/3 + te.src.pos.Y );
				double basic = Math.Pow(dist( te.src.pos, te.dst.pos ), (double) par1/20); 
				
				for (int i = 0 ; i < list.Count /2 ; i++)
				{
					Edge e1 = (Edge) list[2*i];
					Edge e2 = (Edge) list[2*i+1];
					e1.id = i + 1;
					e2.id = - i - 1;
					double lung =  Math.Pow(i+1,(double) par2/20);
					if (basic < 20 ) 
						lung*=20;
					else
						lung*=basic;
					float k =(float) ( lung / Math.Sqrt( n*n + m*m ));
					if (e1.src == te.src)
					{
						e1.p1 = new PointF( -k*n + C.X , k*m+C.Y );
						e1.p2 = new PointF( -k*n + D.X , k*m+D.Y );
					}
					else
					{
						e1.p2 = new PointF( -k*n + C.X , k*m+C.Y );
						e1.p1 = new PointF( -k*n + D.X , k*m+D.Y );
					}
					if (e2.src == te.src)
					{
						e2.p1 = new PointF( k*n + C.X , -k*m+C.Y );
						e2.p2 = new PointF( k*n + D.X , -k*m+D.Y );
					}
					else
					{
						e2.p2 = new PointF( k*n + C.X , -k*m+C.Y );
						e2.p1 = new PointF( k*n + D.X , -k*m+D.Y );
					}
				}
				if (list.Count % 2 == 1)
				{
					Edge e = (Edge) list[list.Count-1];
					e.id = 0;
					e.p1 = e.src.pos;
					e.p2 = e.dst.pos;
				}
			}
			else // edges are loops 
			{
				int k = 70; //vert
				int kk = 110; //oriz

				for (int i = 0 ; i < list.Count /2 ; i++)
				{
					Edge e1 = (Edge) list[2*i];
					Edge e2 = (Edge) list[2*i+1];
					e1.id = i + 1;
					e2.id = - i - 1;
					float f =(float) ( k * ( Math.Pow ( i+1, (double) 2/3 )));
					float ff =(float) ( kk * ( Math.Pow ( i+1, (double) 1/2 )));
					e1.p1 = new PointF( e1.src.pos.X + ff , e1.src.pos.Y - f );
					e1.p2 = new PointF( e1.src.pos.X - ff , e1.src.pos.Y - f );
					e2.p1 = new PointF( e1.src.pos.X + ff , e1.src.pos.Y + f );
					e2.p2 = new PointF( e1.src.pos.X - ff , e1.src.pos.Y + f );
				}
				if (list.Count % 2 == 1)
				{
					Edge e = (Edge) list[list.Count-1];
					e.id = 0;
					float f =(float) ( k * ( Math.Pow ( list.Count /2+1, (double) 2/3 )));
					float ff =(float) ( kk * ( Math.Pow ( list.Count /2+1, (double) 1/2 )));
					e.p1 = new PointF( e.src.pos.X + ff , e.src.pos.Y - f );
					e.p2 = new PointF( e.src.pos.X - ff , e.src.pos.Y - f );
				}
			}					
		}

        public void setAllPoints()  // computes all Bezier control points for all edges
        {
            for (int i = 0; i < vertices.Count; i++)
                for (int j = 0; j <= i; j++)
                    setPoints(getEdges((Vertex)vertices[i], (Vertex)vertices[j]));
        }
         
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static double dist(double x1, double y1, double x2, double y2)
		{
			return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
		}
		
		public static double dist(PointF pf1, PointF pf2)
		{
			return dist(pf1.X, pf1.Y, pf2.X, pf2.Y);
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public override String ToString()
		{
			String rez = " " + name + Path.GetExtension(filename) + " || Vertices:" + vertices.Count + " || Egdes:" + edges.Count;
            computeAlphabet();
            if (isAutomaton())
			{
				if (isDeterministic())
					rez += " || Deterministic Automaton";
				else
					rez += " || Non-deterministic Automaton";
				rez += " || Alphabet: " + alphabet;
			}
			else
			{
				if (oriented) 
					rez += " || Directed";
				else
					rez += " || Undirected";
			}
			return rez;
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool isAutomaton()   // determines if the graph is an automaton
        {
            if (!oriented) return false;    // graph must be oriented

            int nrs = 0;
            foreach (Vertex v in vertices)
                if (v.is_start) nrs++;
            if (nrs != 1) return false;     // must have exactly one start point; implies vertices non-empty !

            Regex rx = new Regex(@"^[a-z]+");   // any number of small letters
            foreach (Edge e in edges)
                if (!rx.IsMatch(e.name)) return false;

            return true;
        }
        
        public bool isDeterministic()   // checks if automaton is deterministic
		{
            foreach (Edge e in edges)
                if (e.name.Length != 1 || e.name.Equals("e")) return false;

			int nrc = (alphabet.Length - 1) / 2;
			foreach (Vertex v in vertices) 
			{
                int nre = 0;
                ArrayList adj_chars = new ArrayList();
                foreach (Edge e in v.edges)
                {
                    if (e.src == v) nre++;
                    if (!adj_chars.Contains(e.name)) adj_chars.Add(e.name);
                }
                if (nre != nrc) return false;   // not enough tranzitions
				if (adj_chars.Count != nrc) return false;  // repeated tranzitions
			}

			return true;
		}

        public void computeAlphabet()
        {
            ArrayList characters = new ArrayList();
            foreach (Edge e in edges)
                for (int i = 0; i < e.name.Length; i++)
                    if (!characters.Contains(e.name[i].ToString())) characters.Add(e.name[i].ToString());
            characters.Sort();
            alphabet = "e";
            foreach (String s in characters) alphabet += " " + s;
            alphabet = alphabet.Replace(" e", "");   // remove if was already added; implies non-deterministic !
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public void arrangeCircle(int width, int height)    // arranges vertices on a circle
		{
			double radius;
			if (height > width) 
				radius = width / 2 - 20;
			else
				radius = height / 2 - 20;
			foreach (Vertex v in vertices)
			{
				v.pos.X = (float) (width / 2 + radius * Math.Cos(2 * Math.PI * v.index / vertices.Count));
				v.pos.Y = (float) (height / 2 + radius * Math.Sin(2 * Math.PI * v.index / vertices.Count));
			}
			setAllPoints();
		}

		public void arrangeGrid(int width, int height)  // arranges vertices on a grid
		{
			int nrp;    // nr of vertices per line
			if ( (int) Math.Sqrt(vertices.Count) * (int) Math.Sqrt(vertices.Count) == vertices.Count)
				nrp = (int) Math.Sqrt(vertices.Count);
			else
				nrp = (int) Math.Ceiling(Math.Sqrt(vertices.Count));
            foreach (Vertex v in vertices)
			{
				v.pos.X = (float) ( (v.index % nrp + 1) * width / (nrp + 1) );
				v.pos.Y = (float) ( (v.index / nrp + 1) * height / (nrp + 1) );
			}
			setAllPoints();
		}
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
		public Graph(String file, int width, int height, int arrangementType)   // reads a graph from file
		{
			vertices = new ArrayList();
			edges = new ArrayList();
            oriented = true;
			
            int nrv = 0, nre = 0, nrf = 0, sind = 0;
			bool needsRearrangement = false;
			
            try 
			{
				using (StreamReader sr = new StreamReader(file)) 
				{
					oriented = (sr.ReadLine().Equals("1"));
					nrv = int.Parse(sr.ReadLine());
					nre = int.Parse(sr.ReadLine());
					nrf = int.Parse(sr.ReadLine());
					sind = int.Parse(sr.ReadLine());
					
                    for (int i = 0; i < nrv; i++)
					{
						String[] ss = sr.ReadLine().Split(new char[]{'#'});
						float fx = float.Parse(ss[1]) * width / 1000;
						float fy = float.Parse(ss[2]) * height / 1000;
						addV(new Vertex(fx, fy, ss[3]));
						if (fx < 0.01f || fx > width || fy < 0.01f || fy > height) needsRearrangement = true;
					}
					
                    if (sind >= 0 && sind < vertices.Count) ((Vertex)vertices[sind]).is_start = true;
					
                    for (int i = 0; i < nre; i++)
					{
						String[] ss = sr.ReadLine().Split(new char[]{'#'});
						int isrc = int.Parse(ss[1]);
						int idst = int.Parse(ss[2]);
                        addEfast(new Edge((Vertex) vertices[isrc],(Vertex) vertices[idst],ss[3]));
					}

					for (int i = 0; i < nrf; i++)
					{
						int ind = int.Parse(sr.ReadLine());
						Vertex v = (Vertex) vertices[ind];
						if (!v.is_start) v.is_finish = true;
					}
				}

				if (needsRearrangement && arrangementType == ARRANGE_CIRCLE) arrangeCircle(width, height);
				if (needsRearrangement && arrangementType == ARRANGE_GRID) arrangeGrid(width, height);

				setAllPoints();
				name = Path.GetFileNameWithoutExtension(file);
				filename = file;
			}
			catch (Exception e) 
			{
				MessageBox.Show("File could not be read: " + file + " -- " + e.Message,"*** Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /*
         * Structure of a valid ".graf" or ".txt" file:
         * 
         * 1st line: 0|1 - orientation (1 for oriented)
         * 2nd line: <nr of vertices>
         * 3rd line: <nr of edges>
         * 4th line: <nr of finish points>
         * 5th line: <index of start point (base 0; -1 for none)> 
         * next <nr of vertices> lines: <vertex index (base 0)> "#" <vertex X wrt 1000> "#" <vertex Y wrt 1000> "#" <vertex name> "#"
         * next <nr of edges> lines: <edge index (base 0)> "#" <source vertex index (base 0)> "#" <destination vertex index (base 0)> "#" <edge name> "#"
         * next <nr of finish points> lines: <vertex index (base 0)>
         * 
         */

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public void save(int width, int height) // saves a graph to file
		{
			if (filename == null || filename.Equals(""))
			{
				if (name == null || name.Equals(""))
				{
					MessageBox.Show("Graph is unnamed and could not be saved!", "*** Output error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else filename = name + ".graf";
            }

			using (StreamWriter sw = new StreamWriter(filename)) 
			{
				int sind = -1, nrf = 0;
				foreach (Vertex v in vertices)
				{
					if (v.is_start) sind = v.index;
					if (v.is_finish) nrf++;
				}

				sw.WriteLine((oriented)?"1":"0");
				sw.WriteLine(vertices.Count);
				sw.WriteLine(edges.Count);
				sw.WriteLine(nrf);
				sw.WriteLine(sind);
				
                foreach (Vertex v in vertices)
				{
					float fx = v.pos.X * 1000 / width;
					float fy = v.pos.Y * 1000 / height;
					sw.WriteLine(v.index + "#" + fx + "#" + fy + "#" + v.name + "#");
				}
				
                foreach (Edge e in edges)
					sw.WriteLine(edges.IndexOf(e) + "#" + e.src.index + "#" + e.dst.index + "#" + e.name + "#");
				
                foreach (Vertex v in vertices)
					if (v.is_finish) sw.WriteLine(v.index);
				
                sw.WriteLine("");
				sw.WriteLine("Saved on: " + DateTime.Now);
				sw.WriteLine("");
				sw.WriteLine("/*");
				sw.WriteLine("* Structure of a valid '.graf' or '.txt' file:");
				sw.WriteLine("* ");
				sw.WriteLine("* 1st line: 0|1 - orientation (1 for oriented)");
				sw.WriteLine("* 2nd line: <nr of vertices>");
				sw.WriteLine("* 3rd line: <nr of edges>");
				sw.WriteLine("* 4th line: <nr of finish points>");
				sw.WriteLine("* 5th line: <index of start point (base 0; -1 for none)> ");
				sw.WriteLine("* next <nr of vertices> lines: <vertex index (base 0)> '#' <vertex X wrt 1000> '#' <vertex Y wrt 1000> '#' <vertex name> '#'");
				sw.WriteLine("* next <nr of edges> lines: <edge index (base 0)> '#' <source vertex index (base 0)> '#' <destination vertex index (base 0)> '#' <edge name> '#'");
				sw.WriteLine("* next <nr of finish points> lines: <vertex index (base 0)>");
				sw.WriteLine("* ");
				sw.WriteLine("*/");
			}
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public Graph(Graph g, int type) : this(g.name + "^", g.oriented) // clones a graph
		{
			Random rnd = new Random();

            if (type == CLONE_1GRAPH || type == CLONE_PGRAPH) oriented = false;
            if (type == CLONE_RANDOM || type == CLONE_DOUBLE || type == CLONE_ORIENTED) oriented = true;

            foreach (Vertex v in g.vertices)
			{
				String vName = null;
				if (v.name != null) vName = string.Copy(v.name);
				Vertex vv = new Vertex(v.pos.X, v.pos.Y, vName);
                vv.is_start = false;
                vv.is_finish = false;
                if (type == CLONE_ORIGINAL)
                {
                    vv.is_start = v.is_start;
                    vv.is_finish = v.is_finish;
                }
				addV(vv);
			}
			
            foreach (Edge e in g.edges)
			{
                if (type == CLONE_VERTICES) break;
                
                String eName = null;
				if (e.name != null) eName = string.Copy(e.name);

                Edge ee = new Edge((Vertex)vertices[e.src.index], (Vertex)vertices[e.dst.index], eName);
                Edge eee = null;

                if (type == CLONE_RANDOM && rnd.NextDouble() < 0.5)
                {
                    ee = new Edge((Vertex)vertices[e.dst.index], (Vertex)vertices[e.src.index], eName);
                }

                if (type == CLONE_DOUBLE)
                {
                    if (e.src != e.dst) eee = new Edge((Vertex)vertices[e.dst.index], (Vertex)vertices[e.src.index], eName);
                }

                if (type == CLONE_1GRAPH)
                {
                    if (getEdges(ee.src, ee.dst).Count > 0) ee = null;
                }

                if (ee != null)
                {
                    ee.color = e.color;
                    addEfast(ee);
                }
                if (eee != null)
                {
                    eee.color = e.color;
                    addEfast(eee);
                }
			}

            setAllPoints();
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public Graph(String graphName, int width, int height, int nrv, int type)  // creates a given type of graph
		{
			vertices = new ArrayList(nrv);
			edges = new ArrayList();
			name = graphName;
			filename = null;
			Random rnd = new Random();

			if (type == TYPE_COMPLETE) // complete (nonoriented) graph of nrv vertices
			{
				oriented = false;
				for (int i = 0; i < nrv; i++) addV(new Vertex(0, 0, ""));
				for (int j = 0; j < nrv; j++)
                    for (int k = 0; k < j; k++)
                        addEfast(new Edge((Vertex)vertices[j], (Vertex)vertices[k], ""));
				arrangeCircle(width,height);
			}

			if (type == TYPE_1GRAPH) //random nonoriented 1-graph of nrv vetices
			{
				oriented = false;
				for (int i = 0; i < nrv; i++) addV(new Vertex((float) rnd.NextDouble() * width, (float) rnd.NextDouble() * height, ""));
				for (int j = 0; j < nrv; j++)
					for (int k = 0; k <= j; k++)
                        if (rnd.NextDouble() < 2.0 / nrv)
                            addEfast(new Edge((Vertex)vertices[j], (Vertex)vertices[k], ""));
 				setAllPoints();
			}

			if (type == TYPE_PGRAPH) //random nonoriented 5-graph of nrv vetices
			{
				oriented = false;
				for (int i = 0; i < nrv; i++) addV(new Vertex((float) rnd.NextDouble() * width, (float) rnd.NextDouble() * height, ""));
                for (int j = 0; j < nrv; j++)
                    for (int k = 0; k <= j; k++)
                        for (int m = 4 - (int)(Math.Sqrt(rnd.NextDouble() * 90)); m >= 0 ; m--)
                            addEfast(new Edge((Vertex)vertices[j], (Vertex)vertices[k], ""));
 				setAllPoints();
			}
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
		public Matrix getMatrix()   // returns corresponding adjacency matrix
		{
			return new Matrix(this);
		}
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void findConnectedComponents()   // finds the (strongly) connected components of the graph by setting component field in Vertex
        {
            DFS_normal();
            if (oriented) DFS_reversed();
        }

        private void DFS_normal()
        {
            components = 0;
            time = 0;
            finished = new ArrayList(vertices.Count);
            foreach (Vertex v in vertices) v.color = Vertex.WHITE;
            foreach (Vertex v in vertices)
                if (v.color == Vertex.WHITE)
                {
                    if (!oriented) components++;
                    DFS_visit(v, false);
                }
        }

        private void DFS_reversed()
        {
            time = 0;
            foreach (Vertex v in vertices) v.color = Vertex.WHITE;
            for (int i = finished.Count - 1; i >= 0; i--)   // reverse DFS finish order
            {
                Vertex v = (Vertex) finished[i];
                if (v.color == Vertex.WHITE)
                {
                    components++;
                    DFS_visit(v, true);
                }
            }
        }

        private void DFS_visit(Vertex v, bool reversed_search)
        {
            time++;
            v.color = Vertex.GRAY;
            if (reversed_search || !oriented) v.component = components;
            foreach (Edge e in v.edges)
            {
                if (e.src == e.dst) continue;
                Vertex u = null;
                if (oriented)
                    if (reversed_search)
                    {
                        if (e.dst == v) u = e.src;
                    }
                    else
                    {
                        if (e.src == v) u = e.dst;
                    }
                if (!oriented)
                {
                    u = (e.src == v) ? e.dst : e.src;
                }
                if (u != null && u.color == Vertex.WHITE) DFS_visit(u, reversed_search);
            }
            v.color = Vertex.BLACK;
            v.finish = ++time;
            if (!reversed_search) finished.Add(v);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Graph getComponentGraph(int width, int height)
        {
            findConnectedComponents();
            Graph graph = new Graph(name + "^", oriented);
            for (int i = 0; i < components; i++) graph.addV(new Vertex(0, 0, null));
            foreach (Vertex v in vertices)
            {
                if (v.is_start) ((Vertex)graph.vertices[v.component - 1]).is_start = true;
                if (v.is_finish) ((Vertex)graph.vertices[v.component - 1]).is_finish = true;
            }
            foreach (Edge e in edges)
                if (e.src.component != e.dst.component)
                {
                    Edge edge = new Edge((Vertex)graph.vertices[e.src.component - 1], (Vertex)graph.vertices[e.dst.component - 1], e.name);
                    edge.color = e.color;
                    graph.addEfast(edge);
                }
            graph.arrangeCircle(width, height);
            return graph;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BFS_explore(Vertex source)
        {
            MyQueue kiu = new MyQueue(vertices.Count);
		    foreach (Vertex v in vertices)
            {
                v.color = Vertex.WHITE;
                v.distance = -1;
                v.parentV = null;
            }
            source.color = Vertex.GRAY;
            source.parentV = null;
            source.distance = 0;
            kiu.add(source);
            while (!kiu.isEmpty())
            {
                Vertex v = (Vertex) kiu.remove();
                foreach (Edge e in v.edges)
                {
                    if (oriented && e.src != v) continue;
                    Vertex u = (e.src == v) ? e.dst : e.src;
                    if (u.color == Vertex.WHITE)
                    {
                        u.distance = v.distance + 1;
                        u.color = Vertex.GRAY;
                        u.parentV = v;
                        kiu.add(u);
                    }
                }
                v.color = Vertex.BLACK;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool setWeights()    // sets edge weights from their info; no info means weight = 1
        {
            try
            {
                foreach (Edge edge in edges)
                {
                    if (edge.name == null || edge.name.Equals(""))
                        edge.weight = 1;
                    else
                        edge.weight = double.Parse(edge.name);
                }
            }
            catch (Exception err)
            {
                return false;
            }
            return true;
        }

        public void unselectAll()   // unselects all vertices
        {
            foreach (Vertex v in vertices) v.selected = false;
        }

        public void clearTechInfo() // clears technical info for vertices and edges
        {
            foreach (Edge edge in edges) edge.tech_color = Color.Black;
            foreach (Vertex vertex in vertices) vertex.tech_name = " ";
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayList getMinSpanTree(int component)  // returns the minimum spanning tree for a connected component
        {
            // assumes nonoriented graph, weights already set, connected components computed and edges sorted

            if (oriented) return null;
            ArrayList tree = new ArrayList(vertices.Count);
            DisjointSet dset = new DisjointSet(vertices.Count);
            foreach (Vertex v in vertices) if (v.component == component) dset.MakeSet(v.index);

            foreach (Edge e in edges)
            {
                if (e.src.component != component || e.dst.component != component) continue;
                int rx = dset.Find(e.src.index);
                int ry = dset.Find(e.dst.index);
                if (rx != ry)
                {
                    tree.Add(e);
                    dset.Union(rx, ry); // sending representatives as arguments to avoid computing them again in dset.union()
                }
            }

            return tree;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void findKClustering(int k)  // finds maximum spacing K-clustering and returns mimimum spacing and total minimum spacing
        {
            clusters = vertices.Count;
            spacing = total_spacing = 0;
            
            ArrayList distances = new ArrayList(vertices.Count * (vertices.Count - 1) / 2);
            for (int i = 0; i < vertices.Count - 1; i++)
                for (int j = i + 1; j < vertices.Count; j++)
                {
                    Edge e = new Edge((Vertex)vertices[i], (Vertex)vertices[j], "");
                    e.weight = dist(((Vertex)vertices[i]).pos, ((Vertex)vertices[j]).pos);
                    distances.Add(e);
                }

            DisjointSet dset = new DisjointSet(vertices.Count);
            foreach (Vertex v in vertices) dset.MakeSet(v.index);
            distances.Sort();

            foreach (Edge e in distances)
            {
                if (clusters == k)
                {
                    spacing = e.weight;
                    break;
                }
                int rx = dset.Find(e.src.index);
                int ry = dset.Find(e.dst.index);
                if (rx != ry)
                {
                    dset.Union(rx, ry);
                    clusters--;
                }
            }

            foreach (Vertex v in vertices) v.repres = dset.Find(v.index);

            double[,] min_dist = new double[vertices.Count, vertices.Count];	// to store minimum spacings between clusters
		    foreach (Edge e in distances)
		    {
			    int i = e.src.repres;
			    int j = e.dst.repres;
			    if ((i != j) && (min_dist[i, j] > e.weight || min_dist[i, j] == 0))	// if a new minimum spacing between clusters i and j..
			    {
				    total_spacing += e.weight - min_dist[i, j];
				    min_dist[i, j] = e.weight;
				    min_dist[j, i] = e.weight;
			    }
		    }

            int current_cluster = 0;
            int[] marked = new int[vertices.Count];	// used to know if a vertex cluster field has been set or not
			foreach (Vertex v in vertices)
			{
				if (marked[v.index] == 0)
				{
					current_cluster++;
                    foreach (Vertex u in vertices)
					{
						if (v.repres == u.repres)
						{
							marked[u.index] = 1;
                            u.cluster = current_cluster;
						}
					}
				}
			}
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool singleSource(Vertex source) // finds all single-source shortest paths on weighted graph
        {
            foreach (Vertex v in vertices)
            {
                v.parentE = null;
                v.cost = double.MaxValue;
            }
            bool is_neg = false;
            foreach (Edge e in edges)
            {
                if (e.weight < 0)
                {
                    is_neg = true; // ? = 0
                    if (e.src == e.dst) return false;   // negative weight loop
                }
            }
            if (!oriented && is_neg) return false;   // neither algorithm applies to a nonoriented graph with negative weights
            if (is_neg)
                return bellman_ford(source);    // oriented graph with negative weights
            else
            {
                dijkstra(source);    // oriented/nonoriented graph with all positive weights
                return true;
            }
        }
        
        private void dijkstra(Vertex source)
        {
            source.cost = 0;
		    MyPriorityQueue kiu = new MyPriorityQueue(vertices);
		
		    while (!kiu.IsEmpty())
		    {
			    Vertex v = (Vertex) kiu.Poll();
			    foreach (Edge e in v.edges)
			    {
                    if (e.src == e.dst) continue;
                    if (oriented && e.src != v) continue;
           			Vertex u = (oriented) ? e.dst : ((e.src == v) ? e.dst : e.src);
                    double d = v.cost + e.weight;
                    if (d < u.cost)
                    {
                        u.cost = d;
                        u.parentE = e;
                    }
				}
			}
		}

        private bool bellman_ford(Vertex source)
        {
            source.cost = 0;

            foreach (Vertex v in vertices)
                foreach (Edge e in edges)
                {
                    if (e.src == e.dst) continue;
                    if (e.src.cost != double.MaxValue)
                    {
                        double d = e.src.cost + e.weight;
                        if (e.dst.cost > d)
                        {
                            e.dst.cost = d;
                            e.dst.parentE = e;
                        }
                    }
                }

            foreach (Edge e in edges)
                if (e.dst.cost > e.src.cost + e.weight) return false; // contains negative weight cycle
            return true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void markEdges() // find all DFS trees and marks edges by type
        {
            clearTechInfo();
            foreach (Vertex v in vertices)
            {
                v.parentV = null;
                v.color = Vertex.WHITE;
                v.start = v.finish = v.distance = -1;
            }
            time = depth = 0;
            foreach (Vertex v in vertices)
                if (v.color == Vertex.WHITE) DFS_edges(v);
            foreach (Vertex v in vertices)
                v.tech_name = "[" + (v.index + 1) + "](" + v.start + "," + v.finish + "){" + v.distance + "}";
        }

        private void DFS_edges(Vertex source)   // DFS_visit method which also marks edges
        {
            source.color = Vertex.GRAY;
            source.distance = depth++;
            source.start = ++time;
            foreach (Edge e in source.edges)
            {
                if (oriented && e.src != source) continue;
                Vertex v = (e.src == source) ? e.dst : e.src;
                if (v.color == Vertex.GRAY && e.tech_color == Color.Black)
                    e.tech_color = Edge.BACK;
                if (v.color == Vertex.BLACK && e.tech_color == Color.Black)
                {
                    if (source.start < v.start)
                        e.tech_color = Edge.FORWARD;
                    else
                        e.tech_color = Edge.CROSS;
                }
                if (v.color == Vertex.WHITE)
                {
                    e.tech_color = Edge.TREE;
                    DFS_edges(v);
                }
            }
            source.color = Vertex.BLACK;
            source.finish = ++time;
            depth--;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool existsEulerPath(Vertex source, Vertex destination) // check if the nonoriented graph has an Euler path
        {
            int degS = source.edges.Count + getEdges(source, source).Count; // degree of source
            int degD = destination.edges.Count + getEdges(destination, destination).Count;  // degree of destination
            if (source != destination)  // a graph has an Euler path if all vertices except path ends have even degree
                if ((degS % 2) == 0 || (degD % 2) == 0) return false; 
            foreach (Vertex v in vertices)  // a graph has an Euler tour if all vertices have even degree
            {
                if (v.component != source.component) continue;  // we're talking about the same connected component
                if ((v == source || v == destination) && (source != destination)) continue;
                if (((v.edges.Count + getEdges(v, v).Count) % 2) != 0) return false;
            }
            return true;
        }

        public ArrayList getEulerPath(Vertex source, Vertex destination)    // gets Euler path between two vertices
        {
            if (!existsEulerPath(source, destination)) return null; // assumes path ends are in the same connected component

            Graph copy = new Graph(this, CLONE_ORIGINAL);   // Euler path find algorithm is destructive; work on a copy
            Stack stack = new Stack(edges.Count);
            ArrayList path = new ArrayList(edges.Count + 2);
            path.Add(destination.index);
            
            Vertex copy_source = (Vertex)copy.vertices[source.index];
            Vertex copy_destination = (Vertex)copy.vertices[destination.index];
            Vertex tour_result = tour(copy_source, stack, copy);
            
            while ((tour_result == copy_source || tour_result == copy_destination) && (stack.Count > 0))
            {
                copy_source = (Vertex) stack.Pop();
                path.Add(copy_source.index);
                tour_result = tour(copy_source, stack, copy);
            }

            return path;
        }

        private Vertex tour(Vertex v, Stack stack, Graph graph) // follows and removes edges on a cyclic path and pushes vertices onto a stack to be checked for side loops
        {
            while (true)
            {
                if (v.edges.Count == 0) break;
                Edge e = (Edge)v.edges[0];
                Vertex w = (e.src == v) ? e.dst : e.src;
                stack.Push(v);
                graph.delEfast(e);
                v = w;
            }
            return v;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayList getTwoWayEulerTour(Vertex source)  // for nonoriented graph, gets a tour that uses each edge exactly twice
        {
            foreach (Vertex v in vertices)
            {
                v.start = v.finish = -1;
                v.color = Vertex.WHITE;
                v.parentV = null;
            }
            time = 0;
            source.parentV = source;
            ArrayList tour = new ArrayList(2 * edges.Count + 2);
            DFS_twoWay(source, tour);
            return tour;
        }

        private void DFS_twoWay(Vertex source, ArrayList tour)
        {
            source.start = ++time;
            source.color = Vertex.GRAY;
            tour.Add(source);
            foreach (Edge e in source.edges)
            {
                if (e.src == e.dst)
                {
                    tour.Add(source);
                    tour.Add(source);
                    continue;
                }
                Vertex u = (e.src == source) ? e.dst : e.src;
                if (u.color == Vertex.WHITE)
                {
                    for (int i = getEdges(u, source).Count - 1; i > 0; i--)
                    {
                        tour.Add(u);
                        tour.Add(source);
                    }
                    u.parentV = source;
                    DFS_twoWay(u, tour);
                }
                else if (u.start < source.parentV.start)
                {
                    tour.Add(u);
                    tour.Add(source);
                }
            }
            time++;
            source.color = Vertex.BLACK;
            if (source != source.parentV) tour.Add(source.parentV);
        }
 
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool isBipartite()   // checks if nonoriented graph is bipartite and 2-colors vertices
        {
            foreach (Vertex v in vertices) v.color = Vertex.GRAY;
            foreach (Vertex v in vertices)
                if (v.color == Vertex.GRAY)
                    if (!DFS_color(v, Vertex.WHITE)) return false;
            return true;
        }

        private bool DFS_color(Vertex v, int color)
        {
            int other_color = (color == Vertex.WHITE) ? Vertex.BLACK : Vertex.WHITE;
            v.color = other_color;
            foreach (Edge e in v.edges)
            {
                if (e.dst == e.src) return false;
                Vertex u = (e.src == v) ? e.dst : e.src;
                if (u.color == Vertex.GRAY)
                {
                    if (!DFS_color(u, other_color)) return false;
                }
                else
                {
                    if (u.color != color) return false;
                }
            }
            return true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
    /************************************************************************************************************/
}