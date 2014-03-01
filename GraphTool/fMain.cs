using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using Graphs;
using Auxiliar;

namespace GraphTool
{
	public class fmain : Form
	{
		#region Borrrring..

		private MainMenu mMenu;
		private PictureBox PB;
		private StatusBar stats;
		private StatusBarPanel statusBarPanel;
		private TabControl tabs;
		private MenuItem mNew;
		private MenuItem mOpen;
		private MenuItem mSave;
		private MenuItem mSaveAs;
		private MenuItem mClose;
		private MenuItem mExit;
		private MenuItem mFile;
		private MenuItem mTools;
		private MenuItem mOptions;
		private MenuItem moSpacing;
		private MenuItem moArrange;
		private MenuItem moDisplayInfo;
		private MenuItem moAntialias;
		private MenuItem moEdit;
		private MenuItem moSp1;
		private MenuItem moSp2;
		private MenuItem moSp3;
		private MenuItem moSp4;
		private MenuItem moGrid;
		private MenuItem moCircle;
		private SaveFileDialog saveFileDialog;
		private OpenFileDialog openFileDialog;
		private MenuItem mMore;
		private MenuItem mmNothing;
		private MenuItem moQuestions;
		private MenuItem mtGenerate;
        private MenuItem mtConvert;
		private MenuItem mtNondeterministic;
		private MenuItem mtDeterministic;
		private MenuItem mtCvOr;
		private MenuItem mtCvOrDouble;
		private MenuItem mtCvOrRandom;
		private MenuItem mtShort;
		private MenuItem mtEqual;
		private MenuItem mtLess;
		private MenuItem mtFinal;
		private MenuItem mtComponents;
		private MenuItem mtCyclomatic;
		private MenuItem moSp5;
		private MenuItem mtCrRandomP;
		private MenuItem mtCvNonP;
		private MenuItem mtCrRandom1;
		private MenuItem mtCrComplete;
		private MenuItem mtCvNon1;
		private MenuItem menuItem4;
		private MenuItem mmHelp;
        private MenuItem mtCrInfo;
        private MenuItem mFloat;
        private MenuItem mtAutomata;
        private MenuItem mtGraphs;
        private MenuItem menuItem13;
        private MenuItem mtMinimize;
        private MenuItem mtLanguage;
        private MenuItem mtTree;
        private MenuItem moConnected;
        private MenuItem moFloat;
        private MenuItem moFl1;
        private MenuItem moFl2;
        private MenuItem moFl3;
        private MenuItem moFl4;
        private MenuItem moFl7;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private MenuItem mtBuild;
        private MenuItem mtMinimum;
        private MenuItem moFl5;
        private MenuItem moFl6;
        private MenuItem mImage;
        private SaveFileDialog saveImageDialog;
        private MenuItem mtCrNo;
        private MenuItem mtCrWeight;
        private MenuItem mtCluster;
        private MenuItem mtArticulation;
        private MenuItem mtMark;
        private MenuItem mtCheck;
        private MenuItem mtEuler;
        private MenuItem mtBipartite;
        private MenuItem mtEulerTwo;
        private IContainer components;

		public fmain()
		{
			InitializeComponent();
			addGraph(null);
		}

		protected override void Dispose(bool disposing)
		{
			if(disposing && components != null) components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		
        private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmain));
            this.mMenu = new System.Windows.Forms.MainMenu(this.components);
            this.mFile = new System.Windows.Forms.MenuItem();
            this.mNew = new System.Windows.Forms.MenuItem();
            this.mOpen = new System.Windows.Forms.MenuItem();
            this.mSave = new System.Windows.Forms.MenuItem();
            this.mSaveAs = new System.Windows.Forms.MenuItem();
            this.mImage = new System.Windows.Forms.MenuItem();
            this.mClose = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mExit = new System.Windows.Forms.MenuItem();
            this.mTools = new System.Windows.Forms.MenuItem();
            this.mtAutomata = new System.Windows.Forms.MenuItem();
            this.mtNondeterministic = new System.Windows.Forms.MenuItem();
            this.mtDeterministic = new System.Windows.Forms.MenuItem();
            this.mtMinimize = new System.Windows.Forms.MenuItem();
            this.mtLanguage = new System.Windows.Forms.MenuItem();
            this.mtFinal = new System.Windows.Forms.MenuItem();
            this.mtGraphs = new System.Windows.Forms.MenuItem();
            this.mtTree = new System.Windows.Forms.MenuItem();
            this.mtCluster = new System.Windows.Forms.MenuItem();
            this.mtShort = new System.Windows.Forms.MenuItem();
            this.mtMinimum = new System.Windows.Forms.MenuItem();
            this.mtArticulation = new System.Windows.Forms.MenuItem();
            this.mtEuler = new System.Windows.Forms.MenuItem();
            this.mtEulerTwo = new System.Windows.Forms.MenuItem();
            this.mtBuild = new System.Windows.Forms.MenuItem();
            this.mtMark = new System.Windows.Forms.MenuItem();
            this.mtCheck = new System.Windows.Forms.MenuItem();
            this.mtBipartite = new System.Windows.Forms.MenuItem();
            this.mtEqual = new System.Windows.Forms.MenuItem();
            this.mtLess = new System.Windows.Forms.MenuItem();
            this.mtComponents = new System.Windows.Forms.MenuItem();
            this.mtCyclomatic = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mtGenerate = new System.Windows.Forms.MenuItem();
            this.mtCrRandomP = new System.Windows.Forms.MenuItem();
            this.mtCrRandom1 = new System.Windows.Forms.MenuItem();
            this.mtCrComplete = new System.Windows.Forms.MenuItem();
            this.mtCrInfo = new System.Windows.Forms.MenuItem();
            this.mtCrWeight = new System.Windows.Forms.MenuItem();
            this.mtCrNo = new System.Windows.Forms.MenuItem();
            this.mtConvert = new System.Windows.Forms.MenuItem();
            this.mtCvNonP = new System.Windows.Forms.MenuItem();
            this.mtCvNon1 = new System.Windows.Forms.MenuItem();
            this.mtCvOr = new System.Windows.Forms.MenuItem();
            this.mtCvOrDouble = new System.Windows.Forms.MenuItem();
            this.mtCvOrRandom = new System.Windows.Forms.MenuItem();
            this.mOptions = new System.Windows.Forms.MenuItem();
            this.moSpacing = new System.Windows.Forms.MenuItem();
            this.moSp1 = new System.Windows.Forms.MenuItem();
            this.moSp2 = new System.Windows.Forms.MenuItem();
            this.moSp3 = new System.Windows.Forms.MenuItem();
            this.moSp4 = new System.Windows.Forms.MenuItem();
            this.moSp5 = new System.Windows.Forms.MenuItem();
            this.moFloat = new System.Windows.Forms.MenuItem();
            this.moFl1 = new System.Windows.Forms.MenuItem();
            this.moFl2 = new System.Windows.Forms.MenuItem();
            this.moFl3 = new System.Windows.Forms.MenuItem();
            this.moFl4 = new System.Windows.Forms.MenuItem();
            this.moFl5 = new System.Windows.Forms.MenuItem();
            this.moFl6 = new System.Windows.Forms.MenuItem();
            this.moFl7 = new System.Windows.Forms.MenuItem();
            this.moArrange = new System.Windows.Forms.MenuItem();
            this.moGrid = new System.Windows.Forms.MenuItem();
            this.moCircle = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.moConnected = new System.Windows.Forms.MenuItem();
            this.moDisplayInfo = new System.Windows.Forms.MenuItem();
            this.moAntialias = new System.Windows.Forms.MenuItem();
            this.moEdit = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.moQuestions = new System.Windows.Forms.MenuItem();
            this.mMore = new System.Windows.Forms.MenuItem();
            this.mmNothing = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.mmHelp = new System.Windows.Forms.MenuItem();
            this.mFloat = new System.Windows.Forms.MenuItem();
            this.PB = new System.Windows.Forms.PictureBox();
            this.stats = new System.Windows.Forms.StatusBar();
            this.statusBarPanel = new System.Windows.Forms.StatusBarPanel();
            this.tabs = new System.Windows.Forms.TabControl();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // mMenu
            // 
            this.mMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mFile,
            this.mTools,
            this.mOptions,
            this.mMore,
            this.mFloat});
            this.mMenu.Collapse += new System.EventHandler(this.mMenu_Collapse);
            // 
            // mFile
            // 
            this.mFile.Index = 0;
            this.mFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mNew,
            this.mOpen,
            this.mSave,
            this.mSaveAs,
            this.mImage,
            this.mClose,
            this.menuItem1,
            this.mExit});
            this.mFile.Text = "&File";
            // 
            // mNew
            // 
            this.mNew.Index = 0;
            this.mNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.mNew.Text = "&New";
            this.mNew.Click += new System.EventHandler(this.mNew_Click);
            // 
            // mOpen
            // 
            this.mOpen.Index = 1;
            this.mOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.mOpen.Text = "&Open..";
            this.mOpen.Click += new System.EventHandler(this.mOpen_Click);
            // 
            // mSave
            // 
            this.mSave.Index = 2;
            this.mSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.mSave.Text = "&Save";
            this.mSave.Click += new System.EventHandler(this.mSave_Click);
            // 
            // mSaveAs
            // 
            this.mSaveAs.Index = 3;
            this.mSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.mSaveAs.Text = "Save &As..";
            this.mSaveAs.Click += new System.EventHandler(this.mSaveAs_Click);
            // 
            // mImage
            // 
            this.mImage.Index = 4;
            this.mImage.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.mImage.Text = "Save &View As..";
            this.mImage.Click += new System.EventHandler(this.mImage_Click);
            // 
            // mClose
            // 
            this.mClose.Index = 5;
            this.mClose.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.mClose.Text = "&Close";
            this.mClose.Click += new System.EventHandler(this.mClose_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 6;
            this.menuItem1.Text = "-";
            // 
            // mExit
            // 
            this.mExit.Index = 7;
            this.mExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.mExit.Text = "&Exit";
            this.mExit.Click += new System.EventHandler(this.mExit_Click);
            // 
            // mTools
            // 
            this.mTools.Index = 1;
            this.mTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mtAutomata,
            this.mtGraphs,
            this.menuItem2,
            this.mtGenerate,
            this.mtConvert});
            this.mTools.Text = "&Tools";
            // 
            // mtAutomata
            // 
            this.mtAutomata.Index = 0;
            this.mtAutomata.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mtNondeterministic,
            this.mtDeterministic,
            this.mtMinimize,
            this.mtLanguage,
            this.mtFinal});
            this.mtAutomata.Text = "Automata";
            // 
            // mtNondeterministic
            // 
            this.mtNondeterministic.Index = 0;
            this.mtNondeterministic.Text = "create a nondeterministic finite automaton with a given accepted language";
            this.mtNondeterministic.Click += new System.EventHandler(this.mtNondeterministic_Click);
            // 
            // mtDeterministic
            // 
            this.mtDeterministic.Index = 1;
            this.mtDeterministic.Text = "convert existing nondeterministic automaton to a deterministic one [slow]";
            this.mtDeterministic.Click += new System.EventHandler(this.mtDeterministic_Click);
            // 
            // mtMinimize
            // 
            this.mtMinimize.Index = 2;
            this.mtMinimize.Text = "minimize existing deterministic automaton [slow]";
            this.mtMinimize.Click += new System.EventHandler(this.mtMinimize_Click);
            // 
            // mtLanguage
            // 
            this.mtLanguage.Enabled = false;
            this.mtLanguage.Index = 3;
            this.mtLanguage.Text = "compute accepted language for existing automaton";
            // 
            // mtFinal
            // 
            this.mtFinal.Index = 4;
            this.mtFinal.Text = "get final state of existing deterministic automaton after a given input string";
            this.mtFinal.Click += new System.EventHandler(this.mtFinal_Click);
            // 
            // mtGraphs
            // 
            this.mtGraphs.Index = 1;
            this.mtGraphs.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mtTree,
            this.mtCluster,
            this.mtShort,
            this.mtMinimum,
            this.mtArticulation,
            this.mtEuler,
            this.mtEulerTwo,
            this.mtBuild,
            this.mtMark,
            this.mtCheck,
            this.mtBipartite,
            this.mtEqual,
            this.mtLess,
            this.mtComponents,
            this.mtCyclomatic});
            this.mtGraphs.Text = "Graphs";
            // 
            // mtTree
            // 
            this.mtTree.Index = 0;
            this.mtTree.Text = "find minimum spanning tree for existing undirected graph";
            this.mtTree.Click += new System.EventHandler(this.mtTree_Click);
            // 
            // mtCluster
            // 
            this.mtCluster.Index = 1;
            this.mtCluster.Text = "find maximum spacing K-clustering using planar vertex coordinates";
            this.mtCluster.Click += new System.EventHandler(this.mtCluster_Click);
            // 
            // mtShort
            // 
            this.mtShort.Index = 2;
            this.mtShort.Text = "find shortest path between two vertices";
            this.mtShort.Click += new System.EventHandler(this.mtShort_Click);
            // 
            // mtMinimum
            // 
            this.mtMinimum.Index = 3;
            this.mtMinimum.Text = "find all single-source minimum cost paths from given vertex ";
            this.mtMinimum.Click += new System.EventHandler(this.mtMinimum_Click);
            // 
            // mtArticulation
            // 
            this.mtArticulation.Enabled = false;
            this.mtArticulation.Index = 4;
            this.mtArticulation.Text = "find articulation points, bridges and biconnected components for existing undirec" +
                "ted graph";
            this.mtArticulation.Click += new System.EventHandler(this.mtArticulation_Click);
            // 
            // mtEuler
            // 
            this.mtEuler.Index = 5;
            this.mtEuler.Text = "find an Euler path between two given vertices for existing undirected graph";
            this.mtEuler.Click += new System.EventHandler(this.mtEuler_Click);
            // 
            // mtEulerTwo
            // 
            this.mtEulerTwo.Index = 6;
            this.mtEulerTwo.Text = "find a two-way Euler tour from a given vertex for existing undirected graph";
            this.mtEulerTwo.Click += new System.EventHandler(this.mtEulerTwo_Click);
            // 
            // mtBuild
            // 
            this.mtBuild.Index = 7;
            this.mtBuild.Text = "build connected components graph for existing one";
            this.mtBuild.Click += new System.EventHandler(this.mtBuild_Click);
            // 
            // mtMark
            // 
            this.mtMark.Index = 8;
            this.mtMark.Text = "mark edges by type through depth-first search in vertex index order";
            this.mtMark.Click += new System.EventHandler(this.mtMark_Click);
            // 
            // mtCheck
            // 
            this.mtCheck.Enabled = false;
            this.mtCheck.Index = 9;
            this.mtCheck.Text = "check graph for planarity";
            // 
            // mtBipartite
            // 
            this.mtBipartite.Index = 10;
            this.mtBipartite.Text = "check existing undirected graph for two-colorability (bipartiteness)";
            this.mtBipartite.Click += new System.EventHandler(this.mtBipartite_Click);
            // 
            // mtEqual
            // 
            this.mtEqual.Index = 11;
            this.mtEqual.Text = "compute number of paths of given length between two vertices";
            this.mtEqual.Click += new System.EventHandler(this.mtEqual_Click);
            // 
            // mtLess
            // 
            this.mtLess.Index = 12;
            this.mtLess.Text = "compute number of paths of length less or equal to given one between two vertices" +
                "";
            this.mtLess.Click += new System.EventHandler(this.mtLess_Click);
            // 
            // mtComponents
            // 
            this.mtComponents.Index = 13;
            this.mtComponents.Text = "compute number of (strongly) connected components of graph";
            this.mtComponents.Click += new System.EventHandler(this.mtComponents_Click);
            // 
            // mtCyclomatic
            // 
            this.mtCyclomatic.Index = 14;
            this.mtCyclomatic.Text = "compute cyclomatic number of graph";
            this.mtCyclomatic.Click += new System.EventHandler(this.mtCyclomatic_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // mtGenerate
            // 
            this.mtGenerate.Index = 3;
            this.mtGenerate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mtCrRandomP,
            this.mtCrRandom1,
            this.mtCrComplete,
            this.mtCrInfo,
            this.mtCrWeight,
            this.mtCrNo});
            this.mtGenerate.Text = "Generate";
            // 
            // mtCrRandomP
            // 
            this.mtCrRandomP.Index = 0;
            this.mtCrRandomP.Text = "random undirected p-graph of given number of vertices";
            this.mtCrRandomP.Click += new System.EventHandler(this.mtCrRandomP_Click);
            // 
            // mtCrRandom1
            // 
            this.mtCrRandom1.Index = 1;
            this.mtCrRandom1.Text = "random undirected 1-graph of given number of vertices";
            this.mtCrRandom1.Click += new System.EventHandler(this.mtCrRandom1_Click);
            // 
            // mtCrComplete
            // 
            this.mtCrComplete.Index = 2;
            this.mtCrComplete.Text = "complete undirected graph of given number of vertices";
            this.mtCrComplete.Click += new System.EventHandler(this.mtCrComplete_Click);
            // 
            // mtCrInfo
            // 
            this.mtCrInfo.Index = 3;
            this.mtCrInfo.Text = "graph with random edge info from existing one";
            this.mtCrInfo.Click += new System.EventHandler(this.mtCrInfo_Click);
            // 
            // mtCrWeight
            // 
            this.mtCrWeight.Index = 4;
            this.mtCrWeight.Text = "graph with random edge weight from existing one";
            this.mtCrWeight.Click += new System.EventHandler(this.mtCrWeight_Click);
            // 
            // mtCrNo
            // 
            this.mtCrNo.Index = 5;
            this.mtCrNo.Text = "graph with no edge info from existing one";
            this.mtCrNo.Click += new System.EventHandler(this.mtCrNo_Click);
            // 
            // mtConvert
            // 
            this.mtConvert.Index = 4;
            this.mtConvert.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mtCvNonP,
            this.mtCvNon1,
            this.mtCvOr,
            this.mtCvOrDouble,
            this.mtCvOrRandom});
            this.mtConvert.Text = "Convert";
            // 
            // mtCvNonP
            // 
            this.mtCvNonP.Index = 0;
            this.mtCvNonP.Text = "to undirected p-graph from directed";
            this.mtCvNonP.Click += new System.EventHandler(this.mtCvNonP_Click);
            // 
            // mtCvNon1
            // 
            this.mtCvNon1.Index = 1;
            this.mtCvNon1.Text = "to undirected 1-graph from directed";
            this.mtCvNon1.Click += new System.EventHandler(this.mtCvNon1_Click);
            // 
            // mtCvOr
            // 
            this.mtCvOr.Index = 2;
            this.mtCvOr.Text = "to directed graph from automata";
            this.mtCvOr.Click += new System.EventHandler(this.mtCvOr_Click);
            // 
            // mtCvOrDouble
            // 
            this.mtCvOrDouble.Index = 3;
            this.mtCvOrDouble.Text = "to directed graph from undirected (by doubling)";
            this.mtCvOrDouble.Click += new System.EventHandler(this.mtCvOrDouble_Click);
            // 
            // mtCvOrRandom
            // 
            this.mtCvOrRandom.Index = 4;
            this.mtCvOrRandom.Text = "to directed graph from undirected (randomly)";
            this.mtCvOrRandom.Click += new System.EventHandler(this.mtCvOrRandom_Click);
            // 
            // mOptions
            // 
            this.mOptions.Index = 2;
            this.mOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.moSpacing,
            this.moFloat,
            this.moArrange,
            this.menuItem3,
            this.moConnected,
            this.moDisplayInfo,
            this.moAntialias,
            this.moEdit,
            this.menuItem5,
            this.moQuestions});
            this.mOptions.Text = "&Options";
            this.mOptions.Select += new System.EventHandler(this.mOptions_Click);
            this.mOptions.Click += new System.EventHandler(this.mOptions_Click);
            // 
            // moSpacing
            // 
            this.moSpacing.Index = 0;
            this.moSpacing.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.moSp1,
            this.moSp2,
            this.moSp3,
            this.moSp4,
            this.moSp5});
            this.moSpacing.Text = "Set edge &spacing";
            // 
            // moSp1
            // 
            this.moSp1.Index = 0;
            this.moSp1.Shortcut = System.Windows.Forms.Shortcut.ShiftF1;
            this.moSp1.Text = "Increase width factor";
            this.moSp1.Click += new System.EventHandler(this.moSp1_Click);
            // 
            // moSp2
            // 
            this.moSp2.Index = 1;
            this.moSp2.Shortcut = System.Windows.Forms.Shortcut.ShiftF2;
            this.moSp2.Text = "Decrease width factor";
            this.moSp2.Click += new System.EventHandler(this.moSp2_Click);
            // 
            // moSp3
            // 
            this.moSp3.Index = 2;
            this.moSp3.Shortcut = System.Windows.Forms.Shortcut.ShiftF3;
            this.moSp3.Text = "Increase height factor";
            this.moSp3.Click += new System.EventHandler(this.moSp3_Click);
            // 
            // moSp4
            // 
            this.moSp4.Index = 3;
            this.moSp4.Shortcut = System.Windows.Forms.Shortcut.ShiftF4;
            this.moSp4.Text = "Decrease height factor";
            this.moSp4.Click += new System.EventHandler(this.moSp4_Click);
            // 
            // moSp5
            // 
            this.moSp5.Index = 4;
            this.moSp5.Shortcut = System.Windows.Forms.Shortcut.ShiftDel;
            this.moSp5.Text = "Reset";
            this.moSp5.Click += new System.EventHandler(this.moSp5_Click);
            // 
            // moFloat
            // 
            this.moFloat.Index = 1;
            this.moFloat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.moFl1,
            this.moFl2,
            this.moFl3,
            this.moFl4,
            this.moFl5,
            this.moFl6,
            this.moFl7});
            this.moFloat.Text = "Set &float parameters";
            // 
            // moFl1
            // 
            this.moFl1.Index = 0;
            this.moFl1.Shortcut = System.Windows.Forms.Shortcut.CtrlF1;
            this.moFl1.Text = "Increase target edge length";
            this.moFl1.Click += new System.EventHandler(this.moFl1_Click);
            // 
            // moFl2
            // 
            this.moFl2.Index = 1;
            this.moFl2.Shortcut = System.Windows.Forms.Shortcut.CtrlF2;
            this.moFl2.Text = "Decrease target edge length";
            this.moFl2.Click += new System.EventHandler(this.moFl2_Click);
            // 
            // moFl3
            // 
            this.moFl3.Index = 2;
            this.moFl3.Shortcut = System.Windows.Forms.Shortcut.CtrlF3;
            this.moFl3.Text = "Increase speed";
            this.moFl3.Click += new System.EventHandler(this.moFl3_Click);
            // 
            // moFl4
            // 
            this.moFl4.Index = 3;
            this.moFl4.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
            this.moFl4.Text = "Decrease speed";
            this.moFl4.Click += new System.EventHandler(this.moFl4_Click);
            // 
            // moFl5
            // 
            this.moFl5.Index = 4;
            this.moFl5.Shortcut = System.Windows.Forms.Shortcut.CtrlF5;
            this.moFl5.Text = "Increase elasticity constant";
            this.moFl5.Click += new System.EventHandler(this.moFl5_Click);
            // 
            // moFl6
            // 
            this.moFl6.Index = 5;
            this.moFl6.Shortcut = System.Windows.Forms.Shortcut.CtrlF6;
            this.moFl6.Text = "Decrease elasticity constant";
            this.moFl6.Click += new System.EventHandler(this.moFl6_Click);
            // 
            // moFl7
            // 
            this.moFl7.Index = 6;
            this.moFl7.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
            this.moFl7.Text = "Reset";
            this.moFl7.Click += new System.EventHandler(this.moFl7_Click);
            // 
            // moArrange
            // 
            this.moArrange.Index = 2;
            this.moArrange.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.moGrid,
            this.moCircle});
            this.moArrange.Text = "Arrange &vertices";
            // 
            // moGrid
            // 
            this.moGrid.Index = 0;
            this.moGrid.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.moGrid.Text = "Grid";
            this.moGrid.Click += new System.EventHandler(this.moGrid_Click);
            // 
            // moCircle
            // 
            this.moCircle.Index = 1;
            this.moCircle.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
            this.moCircle.Text = "Circle";
            this.moCircle.Click += new System.EventHandler(this.moCircle_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // moConnected
            // 
            this.moConnected.Index = 4;
            this.moConnected.Text = "Show &connected components";
            this.moConnected.Click += new System.EventHandler(this.moConnected_Click);
            // 
            // moDisplayInfo
            // 
            this.moDisplayInfo.Checked = true;
            this.moDisplayInfo.Index = 5;
            this.moDisplayInfo.Text = "Display edge &info";
            this.moDisplayInfo.Click += new System.EventHandler(this.moDisplayInfo_Click);
            // 
            // moAntialias
            // 
            this.moAntialias.Checked = true;
            this.moAntialias.Index = 6;
            this.moAntialias.Text = "Use &antialiasing";
            this.moAntialias.Click += new System.EventHandler(this.moAntialias_Click);
            // 
            // moEdit
            // 
            this.moEdit.Index = 7;
            this.moEdit.Text = "&Edit info right after adding new";
            this.moEdit.Click += new System.EventHandler(this.moEdit_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 8;
            this.menuItem5.Text = "-";
            this.menuItem5.Visible = false;
            // 
            // moQuestions
            // 
            this.moQuestions.Enabled = false;
            this.moQuestions.Index = 9;
            this.moQuestions.Text = "Great questions of mankind..";
            this.moQuestions.Visible = false;
            this.moQuestions.Click += new System.EventHandler(this.moQuestions_Click);
            // 
            // mMore
            // 
            this.mMore.Index = 3;
            this.mMore.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mmNothing,
            this.menuItem6,
            this.mmHelp});
            this.mMore.Text = "&More";
            // 
            // mmNothing
            // 
            this.mmNothing.Index = 0;
            this.mmNothing.Text = "About";
            this.mmNothing.Click += new System.EventHandler(this.mmNothing_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.Text = "-";
            // 
            // mmHelp
            // 
            this.mmHelp.Index = 2;
            this.mmHelp.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.mmHelp.Text = "Quick &Help";
            this.mmHelp.Click += new System.EventHandler(this.mmHelp_Click);
            // 
            // mFloat
            // 
            this.mFloat.Index = 4;
            this.mFloat.Text = "&Float!";
            this.mFloat.Click += new System.EventHandler(this.mFloat_Click);
            // 
            // PB
            // 
            this.PB.BackColor = System.Drawing.SystemColors.Info;
            this.PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB.Location = new System.Drawing.Point(3, 30);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(417, 325);
            this.PB.TabIndex = 0;
            this.PB.TabStop = false;
            this.PB.DoubleClick += new System.EventHandler(this.PB_DoubleClick);
            this.PB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_MouseMove);
            this.PB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_MouseDown);
            this.PB.Paint += new System.Windows.Forms.PaintEventHandler(this.PB_Paint);
            this.PB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PB_MouseUp);
            // 
            // stats
            // 
            this.stats.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stats.Location = new System.Drawing.Point(0, 360);
            this.stats.Name = "stats";
            this.stats.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel});
            this.stats.ShowPanels = true;
            this.stats.Size = new System.Drawing.Size(424, 22);
            this.stats.TabIndex = 1;
            this.stats.Text = "statusBar1";
            // 
            // statusBarPanel
            // 
            this.statusBarPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel.Icon")));
            this.statusBarPanel.Name = "statusBarPanel";
            this.statusBarPanel.Text = " Status";
            this.statusBarPanel.Width = 407;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.HotTrack = true;
            this.tabs.Location = new System.Drawing.Point(3, 3);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(418, 25);
            this.tabs.TabIndex = 2;
            this.tabs.DoubleClick += new System.EventHandler(this.tabs_DoubleClick);
            this.tabs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabs_MouseClick);
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "graf";
            this.saveFileDialog.Filter = "Graph file (*.graf)|*.graf|Text File (*.txt)|*.txt";
            this.saveFileDialog.Title = "*** Save the current graph to a text file";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Graph files (*.graf; *.txt) |*.graf;*.txt";
            this.openFileDialog.Title = "*** Open a graph file";
            // 
            // saveImageDialog
            // 
            this.saveImageDialog.Filter = "JPEG file (*.jpg)|*.jpg|Bitmap file (*.bmp)|*.bmp";
            this.saveImageDialog.Title = "*** Save the current graph view to an image file";
            // 
            // fmain
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(424, 382);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.stats);
            this.Controls.Add(this.PB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Menu = this.mMenu;
            this.MinimumSize = new System.Drawing.Size(430, 400);
            this.Name = "fmain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Tool 2.1";
            this.Load += new System.EventHandler(this.fmain_Load);
            this.SizeChanged += new System.EventHandler(this.fmain_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fmain_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new fmain());
		}
		#endregion

		Graph g;                                // current graph displayed
		ArrayList gList = new ArrayList();      // graph list corresponding to tab list
		
        bool moving = false;                    // vertex move flag
        bool adding = false;                    // edge adding flag
        bool rect_drag = false;                 // multiple vertex selection flag
        bool tech_info = false;                 // graph algorithms mode flag
        bool show_ctrl = false;                 // show Bezier curve control points flag
        bool no_edges = false;                  // draw edges flag

        Edge hover_edge;                        // edge mouse is hovering on
		Vertex hover_vert;                      // vertex mouse is hovering on
		Vertex prev_vert;                       // previously selected vertex when adding edges

        GraphFloater floater;                   // floats current graph
		
        PointF mouse = new PointF(0, 0);        // mouse position on picture box PB
        Point rect_prev = new Point();          // previous point for selection rectangle
        Point rect_curr = new Point();          // current point for selection rectangle
        Random rnd = new Random();              // random number generator
        Point[] arrow = {                       // used to represent orientation arrows on edges
            new Point(-5, -3), 
            new Point(-5, 3), 
            new Point(5, 0)
            };

        Color EDGE_TECHNICAL = Color.Red;
        Color EDGE_SELECTED = Color.Crimson;
        Color EDGE_COMPONENT = Color.DarkRed;
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void addGraph(Graph graph)   // adds a graph in a new tab
        {
            if (g != null)
            {
                g.unselectAll();
                stopFloater();
            }
            if (graph == null)
            {
                tabs.TabPages.Add(new TabPage("Graph" + (tabs.TabPages.Count + 1)));
                g = new Graph("Graph" + tabs.TabPages.Count, true);
                g.addV(new Vertex(100, 100, ""));
                g.addV(new Vertex(300, 150, ""));
                g.addE(new Edge((Vertex)g.vertices[0], (Vertex)g.vertices[0], ""));
                g.addE(new Edge((Vertex)g.vertices[0], (Vertex)g.vertices[1], ""));
                ((Vertex)g.vertices[1]).is_start = true;
                ((Vertex)g.vertices[0]).is_finish = true;
            }
            else if (graph.name == null)
            {
                tabs.TabPages.Add(new TabPage("Graph" + (tabs.TabPages.Count + 1)));
                g = graph;
                g.name = "Graph" + tabs.TabPages.Count;
            }
            else
            {
                tabs.TabPages.Add(new TabPage(graph.name));
                g = graph;
            }
            gList.Add(g);
            if (moConnected.Checked) g.findConnectedComponents();
            stats.Panels[0].Text = g.ToString();
            tabs.SelectedIndex = tabs.TabPages.Count - 1;
            PB.Refresh();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void mNew_Click(object sender, EventArgs e)
        {
            if (tabs.TabPages.Count > 20)
                MessageBox.Show("Too many graphs open @ the same time!", "*** Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
                addGraph(null);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
		{
            g.unselectAll();
            stopFloater();
            g = (Graph) gList[tabs.SelectedIndex];
            if (moConnected.Checked) g.findConnectedComponents();
            stats.Panels[0].Text = g.ToString();
			PB.Refresh();
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void tabs_DoubleClick(object sender, EventArgs e)
		{
			if (tabs.TabPages.Count > 1) 
			{
				gList.Remove(g);
				tabs.TabPages.RemoveAt(tabs.SelectedIndex);
				g = (Graph) gList[tabs.SelectedIndex];
                if (moConnected.Checked) g.findConnectedComponents();
                stats.Panels[0].Text = g.ToString();
				PB.Refresh();
			}
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public void changeQuestion()    // changes the question displayed in the menu
        {
            moQuestions.Enabled = (rnd.NextDouble() < 0.35);
            switch (rnd.Next(8))
	        {
                case 0:
                    moQuestions.Text = "Who are we?";
                    break;
                case 1:
                    moQuestions.Text = "Where do we come from?";
                    break;
                case 2:
                    moQuestions.Text = "Why are we here?";
                    break;
                case 3:
                    moQuestions.Text = "How did we get here?";
                    break;
                case 4:
                    moQuestions.Text = "Who created the Universe?";
                    break;
                case 5:
                    moQuestions.Text = "Are aliens real?";
                    break;
                case 6:
                    moQuestions.Text = "Is God real?";
                    break;
                case 7:
                    moQuestions.Text = "Who created mankind?";
                    break;
		        default:
                    moQuestions.Text = "Great questions of mankind..";
                    break;
	        }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void PB_Paint(object sender, PaintEventArgs e)
		{
            if (moAntialias.Checked)
			{
				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
				//e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			}
			else
			{
				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
				e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			}

            if (rect_drag)
            {
                Rectangle rectangle = new Rectangle(
                    Math.Min(rect_prev.X, rect_curr.X),
                    Math.Min(rect_prev.Y, rect_curr.Y),
                    Math.Abs(rect_prev.X - rect_curr.X),
                    Math.Abs(rect_prev.Y - rect_curr.Y)
                    );

                e.Graphics.FillRectangle(
                    new System.Drawing.Drawing2D.HatchBrush(
                        System.Drawing.Drawing2D.HatchStyle.Percent10,
                        Color.Violet,
                        PB.BackColor
                    ), rectangle);

                Pen pencil = new Pen(Color.DarkViolet, 1);
                pencil.DashPattern = new float[] { 3.0F, 3.0F, 1.0F, 3.0F };
                e.Graphics.DrawRectangle(pencil, rectangle);

                Vertex u = null;
                int selected_count = 0;
                foreach (Vertex v in g.vertices)
                {
                    v.selected = rectangle.Contains((int)v.pos.X, (int)v.pos.Y);
                    if (v.selected)
                    {
                        selected_count++;
                        u = v;
                    }
                }
                //if (selected_count == 1) u.selected = false;    // at least two points needed for multiple select
            }
            
            Font f1 = new Font("Courier New", 8, System.Drawing.FontStyle.Bold);
			Font f2 = new Font("Tahoma", 9, System.Drawing.FontStyle.Regular);
			
			foreach (Edge edge in g.edges)
			{
                if (no_edges) break;

                Pen pen = new Pen(edge.color, 1);
                if (moConnected.Checked == true)
                {
                    if (edge.src.component == edge.dst.component)
                        pen = new Pen(EDGE_COMPONENT, 1);
                    else
                        pen = new Pen(Color.Black, 1);
                }
                if (tech_info) pen = new Pen(edge.tech_color, (edge.tech_color != Color.Black) ? 2 : 1);
                if (hover_edge == edge && !moving && !adding) pen = new Pen(EDGE_SELECTED, 3);
					
				e.Graphics.DrawBezier(pen, edge.src.pos, edge.p1, edge.p2, edge.dst.pos);
				
                String eName;
				if (edge.name == null || edge.name.Equals("")) 
					eName = "(" + (edge.src.index + 1) + "," + (edge.dst.index + 1) + ")";
				else 
					eName = edge.name;

				if (moDisplayInfo.Checked || g.oriented || show_ctrl)
				{
					PointF pos = edge.EvalBezier(0.5f);
					PointF tangent = new PointF(edge.p2.X - edge.p1.X, edge.p2.Y - edge.p1.Y);
					double angle = Math.Atan2(tangent.Y, tangent.X) / Math.PI * 180;
					if (g.oriented)
					{
						e.Graphics.TranslateTransform(pos.X, pos.Y);
						e.Graphics.RotateTransform((float) angle);
						e.Graphics.FillPolygon(Brushes.DarkOrange, arrow);
						e.Graphics.ResetTransform();
					}
					if (moDisplayInfo.Checked && !moving)
					{
						SizeF dimS = e.Graphics.MeasureString(eName, f2);
						if (angle < -90.0) angle = angle + 180.0;
						if (angle > 90.0) angle = angle - 180.0;
						e.Graphics.TranslateTransform(pos.X, pos.Y);
						e.Graphics.RotateTransform((float) angle);
						e.Graphics.DrawString(eName, f2, Brushes.DarkRed, -dimS.Width/2, -dimS.Height);
						e.Graphics.ResetTransform();
					}
					if (show_ctrl)
					{
						Pen p = new Pen(Color.Pink,2);
						int r = 3;
						e.Graphics.DrawEllipse(p,edge.p1.X - r, edge.p1.Y - r, 2*r, 2*r);
						e.Graphics.DrawEllipse(p,edge.p2.X - r, edge.p2.Y - r, 2*r, 2*r);
					}
				}
			}
		
			foreach (Vertex vertex in g.vertices)
			{
				String vName;
				if (vertex.name == null || vertex.name.Equals("")) 
					vName = "[" + (vertex.index + 1)+ "]";
				else 
					vName = vertex.name;
                if (moConnected.Checked) vName += "~c." + vertex.component + "/" + g.components;
                if (tech_info) vName = vertex.tech_name;
            			
				SizeF pxlen = e.Graphics.MeasureString(vName, f1);
				PointF pos = new PointF(vertex.pos.X - pxlen.Width / 2, vertex.pos.Y - pxlen.Height - 5);
     
				Brush brush = Brushes.BlueViolet;
				if (vertex == hover_vert || vertex.selected)
				{
					brush = Brushes.Crimson;
					if (moving) brush = Brushes.LightCyan;
					if (adding) brush = Brushes.Firebrick;
				}
		
				e.Graphics.DrawString(vName, f1, Brushes.DarkBlue, pos, null);
				e.Graphics.FillEllipse(brush, vertex.pos.X - 3, vertex.pos.Y - 3, 6, 6);

				if (adding && prev_vert != null)
				{
					e.Graphics.DrawLine(Pens.Blue, ((Vertex)prev_vert).pos, mouse);
				}
		
				Pen pen = new Pen(Color.Black, 1);
				if ((vertex == hover_vert || vertex.selected) && moving) pen = new Pen(Color.DarkViolet, 3);
				if (vertex == hover_vert && adding) 
				{
					pen = new Pen(Color.Blue, 1);
					e.Graphics.DrawEllipse(pen, vertex.pos.X - 8, vertex.pos.Y - 8, 16, 16);
					e.Graphics.DrawEllipse(pen, vertex.pos.X - 10, vertex.pos.Y - 10, 20, 20);
					e.Graphics.DrawEllipse(pen, vertex.pos.X - 12, vertex.pos.Y - 12, 24, 24);
					e.Graphics.DrawEllipse(pen, vertex.pos.X - 14, vertex.pos.Y - 14, 28, 28);
				}
			
				if (vertex.is_start) 
				{		
					Pen pen2 = new Pen(Color.Green,4);
					e.Graphics.DrawLine(pen2, new PointF(vertex.pos.X - 10, vertex.pos.Y - 6), new PointF(vertex.pos.X - 5, vertex.pos.Y));
					e.Graphics.DrawLine(pen2, new PointF(vertex.pos.X - 10, vertex.pos.Y + 6), new PointF(vertex.pos.X - 5, vertex.pos.Y));
					e.Graphics.DrawEllipse(Pens.DimGray, vertex.pos.X - 6, vertex.pos.Y - 6, 12, 12);
				}
		
				if (vertex.is_finish) 
				{		
					Pen pen2 = new Pen(Color.DarkRed,2);
					e.Graphics.DrawEllipse(pen2, vertex.pos.X - 6, vertex.pos.Y - 6, 12, 12);
				}

				e.Graphics.DrawEllipse(pen, vertex.pos.X - 4, vertex.pos.Y - 4, 8, 8);
			}
		
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void PB_MouseMove(object sender, MouseEventArgs e)
		{
            if (rect_drag)
            {
                rect_curr = e.Location;
                PB.Refresh();
                return;
            }
            
            mouse = new PointF(e.X, e.Y);
			if (mouse.X < 4) mouse.X = 4;
			if (mouse.X > PB.Width - 4) mouse.X = PB.Width - 4;
			if (mouse.Y < 4) mouse.Y = 4;
			if (mouse.Y > PB.Height - 4) mouse.Y = PB.Height - 4;

			if (moving)
			{
                if (hover_vert != null)
                {
                    float dx = mouse.X - hover_vert.pos.X;
                    float dy = mouse.Y - hover_vert.pos.Y;
                    if (hover_vert.selected)
                        foreach (Vertex v in g.vertices)
                        {
                            if (v.selected && v != hover_vert)
                            {
                                v.pos.X += dx;
                                if (v.pos.X > PB.Width - 4) v.pos.X = PB.Width - 4;
                                if (v.pos.X < 4) v.pos.X = 4;
                                v.pos.Y += dy;
                                if (v.pos.Y > PB.Height - 4) v.pos.Y = PB.Height - 4;
                                if (v.pos.Y < 4) v.pos.Y = 4;
                            }
                        }
                    //hover_vert.selected = true;
                    hover_vert.pos = mouse;
                }
				g.setAllPoints();
				PB.Refresh();
				return;
			}
			
			Edge old_edge = hover_edge;
			hover_edge = null;
			
			foreach (Edge edge in g.edges)
			{
				if (edge.getDist(mouse) < 3 && hover_vert == null) hover_edge = edge;
			}
			
			Vertex old_vert = hover_vert;
			hover_vert = null;
			
			foreach (Vertex v in g.vertices)
			{
				if ((e.X - v.pos.X) * (e.X - v.pos.X) + (e.Y - v.pos.Y) * (e.Y - v.pos.Y) < 64)	hover_vert = v;
			}
			
			if (old_vert != hover_vert || old_edge != hover_edge)
			{
				PB.Refresh();
				return;
			}

			if (adding && prev_vert != null)
			{
				PB.Refresh();
				return;
			}
		}

		private void PB_MouseDown(object sender, MouseEventArgs e)
		{
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
                if (hover_edge == null && hover_vert == null) g.unselectAll();
                
                if (hover_vert == null)
                {
                    rect_prev = e.Location;
                    rect_curr = e.Location;
                    rect_drag = true;
                }
                
                if (hover_vert != null && !adding)
				{
					moving = true;
					PB.Refresh();
					return;
				}
				
				if (hover_vert != null && prev_vert == null && adding )
				{
					prev_vert = hover_vert;
					PB.Refresh();
					return;
				}

				if (hover_vert != null && prev_vert != null && adding )
				{
					g.addE(new Edge(prev_vert, hover_vert, ""));
                    if (moConnected.Checked) g.findConnectedComponents();
					stats.Panels[0].Text = g.ToString();
					adding = false;
					prev_vert = null;
					PB.Refresh();
					if (moEdit.Checked) editEdge((Edge) g.edges[g.edges.Count-1]);
					return;
				}
			}
			
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				
				if (hover_vert == null && hover_edge == null && !adding && !moving)
				{
					if (g.vertices.Count > 150) 
					{
						MessageBox.Show(this," Stop that clicking!","*** Too many vertices", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
						return;
					}
					hover_vert = new Vertex(e.X, e.Y, "");
					g.addV(hover_vert);
                    if (moConnected.Checked) g.findConnectedComponents();
                    stats.Panels[0].Text = g.ToString();
					PB.Refresh();
					moving = false;
					adding = false;
					if (moEdit.Checked) editVert(hover_vert);
					return;
				}
							
				if (hover_vert != null && !adding && !moving)
				{
					g.delV(hover_vert);
                    if (hover_vert.selected)
                    {
                        ArrayList sel_vert = new ArrayList(g.vertices.Count);
                        foreach (Vertex u in g.vertices) if (u.selected) sel_vert.Add(u);
                        foreach (Vertex u in sel_vert) g.delV(u);
                    }
                    if (moConnected.Checked) g.findConnectedComponents();
                    stats.Panels[0].Text = g.ToString();
					hover_vert = null;
					PB.Refresh();
					moving = false;
					adding = false;
					return;
				}
				
				if (hover_edge != null && !adding && !moving)
				{
					g.delE(hover_edge);
                    if (moConnected.Checked) g.findConnectedComponents();
                    stats.Panels[0].Text = g.ToString();
					hover_edge = null;
					PB.Refresh();
					moving = false;
					adding = false;
					return;
				}
			}
			PB.Refresh();
		}

		private void PB_MouseUp(object sender, MouseEventArgs e)
		{
            rect_drag = false;
            moving = false;
			PB.Refresh();
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void fmain_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				show_ctrl = !show_ctrl;
				PB.Refresh();
			}
			
			if (e.Control == true)
			{
				if (!adding)
				{
					adding = true;
                    moving = false;
                    hover_edge = null;
					prev_vert = null;
				}
			}
		}

		private void fmain_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Control == false)
			{
				adding = false;
				prev_vert = null;
				PB.Refresh();
			}
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void fmain_Load(object sender, EventArgs e)
		{
		    // nothing yet..
		}

        private void mMenu_Collapse(object sender, EventArgs e)
        {
            // g.unselectAll();
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void PB_DoubleClick(object sender, System.EventArgs e)
		{
			if (!adding)
			{
				editVert(hover_vert);
				if (hover_vert != null) return;
				editEdge(hover_edge);
			}
		}

		public void editEdge(Edge e)    // opens the edge editor
		{
			if (e != null)
			{
				AEdit AE = new AEdit(PB, e, g);
				stats.Panels[0].Text = g.ToString();
			}
		}

		public void editVert(Vertex v)  // opens the vertex editor
		{
			if (v != null)
			{
				VEdit VE = new VEdit(PB, v, g);
 				stats.Panels[0].Text = g.ToString();
			}
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void fmain_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width - 15 < 100 || this.Height - 112 < 100) return;
            foreach (Graph gg in gList)
            {
                foreach (Vertex gv in gg.vertices)
                {
                    gv.pos.X = (gv.pos.X * (this.Width - 15) / PB.Width);
                    gv.pos.Y = (gv.pos.Y * (this.Height - 112) / PB.Height);
                }
                gg.setAllPoints();
            }
            PB.Size = new Size(this.Width - 15, this.Height - 112);
            PB.Refresh();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void mOptions_Click(object sender, EventArgs e)
        {
            changeQuestion();
        }

        private void moQuestions_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Sorry, I don't know that yet.. But I'm working on it!\n I'll put you up to date if you send your request to:\n axel_kosmo@yahoo.com ","*** I don't know..", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void moConnected_Click(object sender, EventArgs e)
        {
            moConnected.Checked = !moConnected.Checked;
            if (moConnected.Checked) g.findConnectedComponents();
            PB.Refresh();
        }

        private void mmHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Right click empty space - Add vertex \n[Ctrl]+click vertex - Add edge " +
                "\nClick & drag vertex - Move vertex \nClick & drag empty space - Multiple select " +
                "\nClick empty space - Unselect all \nDouble click vertex/edge - Edit vertex/edge " +
                "\nRight click vertex/edge - Delete vertex/edge \nDouble click tab - Close graph " +
                "\nClick tab while floating - Scramble ", "*** Help",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void moDisplayInfo_Click(object sender, EventArgs e)
        {
            moDisplayInfo.Checked = !moDisplayInfo.Checked;
            PB.Refresh();
        }

        private void moAntialias_Click(object sender, EventArgs e)
        {
            moAntialias.Checked = !moAntialias.Checked;
            PB.Refresh();
        }

        private void moEdit_Click(object sender, EventArgs e)
        {
            moEdit.Checked = !moEdit.Checked;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void mOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                addGraph(new Graph(openFileDialog.FileName, PB.Width, PB.Height, Graph.ARRANGE_CIRCLE));
        }

        private void mSave_Click(object sender, EventArgs e)
        {
            g.save(PB.Width, PB.Height);
            if (File.Exists(g.filename))
                MessageBox.Show("File saved successfully: \n" + g.filename, "*** Output success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            stats.Panels[0].Text = g.ToString();
        }

        private void mSaveAs_Click(object sender, EventArgs e)
        {
            if (g.filename == null || g.filename.Equals(""))
                saveFileDialog.FileName = g.name;
            else
                saveFileDialog.FileName = g.filename;
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                g.filename = saveFileDialog.FileName;
                g.name = Path.GetFileNameWithoutExtension(g.filename);
                tabs.TabPages[tabs.SelectedIndex].Text = g.name;
                g.save(PB.Width, PB.Height);
                stats.Panels[0].Text = g.ToString();
                if (!File.Exists(saveFileDialog.FileName))
                    MessageBox.Show("Graph did not save: " + saveFileDialog.FileName, "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Save changes before exit? ", "*** Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr.Equals(DialogResult.Cancel)) return;
            if (dr.Equals(DialogResult.Yes))
            {
                foreach (Graph graph in gList) graph.save(PB.Width, PB.Height);
            }
            Application.Exit();
        }

        private void mClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Save changes before closing graph? ", "*** Close", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr.Equals(DialogResult.Cancel)) return;
            if (dr.Equals(DialogResult.Yes))
            {
                g.save(PB.Width, PB.Height);
                if (File.Exists(g.filename))
                    MessageBox.Show("File saved successfully: " + g.filename, "*** Output success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (tabs.TabPages.Count > 1)
            {
                gList.Remove(g);
                tabs.TabPages.RemoveAt(tabs.SelectedIndex);
                g = (Graph)gList[tabs.SelectedIndex]; 
                if (moConnected.Checked) g.findConnectedComponents();
				PB.Refresh();
            }
            stats.Panels[0].Text = g.ToString();
        }

        private void mImage_Click(object sender, EventArgs e)
        {
            saveImageDialog.FileName = g.name;
            if (saveImageDialog.ShowDialog(this) == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap (PB.Width, PB.Height, PixelFormat.Format32bppArgb);
                PB.DrawToBitmap(bitmap, new Rectangle(0, 0, PB.Width, PB.Height));
                if (saveImageDialog.FilterIndex == 1)
                    bitmap.Save(saveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (saveImageDialog.FilterIndex == 2)
                    bitmap.Save(saveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                if (!File.Exists(saveImageDialog.FileName))
                    MessageBox.Show("Image did not save: " + saveImageDialog.FileName, "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bitmap.Dispose();
            }
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void moSp1_Click(object sender, EventArgs e)
        {
            Graph.par1++;
			moSp2.Enabled = (Graph.par1 > 3);
			moSp1.Enabled = (Graph.par1 < 40);
			foreach (Graph graph in gList) graph.setAllPoints();
			PB.Refresh();
        }

        private void moSp2_Click(object sender, EventArgs e)
        {
            Graph.par1--;
            moSp2.Enabled = (Graph.par1 > 3);
            moSp1.Enabled = (Graph.par1 < 40);
            foreach (Graph graph in gList) graph.setAllPoints();
			PB.Refresh();
        }

        private void moSp3_Click(object sender, EventArgs e)
        {
            Graph.par2++;
            moSp4.Enabled = (Graph.par2 > 3);
            moSp3.Enabled = (Graph.par2 < 40);
            foreach (Graph graph in gList) graph.setAllPoints();
			PB.Refresh();
        }

        private void moSp4_Click(object sender, EventArgs e)
        {
            Graph.par2--;
            moSp4.Enabled = (Graph.par2 > 3);
            moSp3.Enabled = (Graph.par2 < 40);
            foreach (Graph graph in gList) graph.setAllPoints();
			PB.Refresh();
        }

        private void moSp5_Click(object sender, EventArgs e)
        {
            Graph.par1 = 11;
			Graph.par2 = 22;
			moSp1.Enabled = true;
			moSp2.Enabled = true;
			moSp3.Enabled = true;
			moSp4.Enabled = true;
			foreach (Graph graph in gList) graph.setAllPoints();
			PB.Refresh();
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void moGrid_Click(object sender, EventArgs e)
        {
            g.arrangeGrid(PB.Width, PB.Height);
            hover_vert = null;
            prev_vert = null;
            hover_edge = null;
            adding = false;
            moving = false;
            PB.Refresh();
        }

        private void moCircle_Click(object sender, EventArgs e)
        {
            g.arrangeCircle(PB.Width, PB.Height);
            hover_vert = null;
            prev_vert = null;
            hover_edge = null;
            adding = false;
            moving = false;
            PB.Refresh();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void mFloat_Click(object sender, EventArgs e)
        {
            if (mFloat.Text.Equals("&Float!"))
            {
                floater = new GraphFloater(PB, g);
                floater.start();
                mFloat.Text = "&Stop!";
            }
            else
            {
                stopFloater();
            }
        }

        private void stopFloater()
        {
            if (floater != null) floater.stop();
            mFloat.Text = "&Float!";
        }

        private void tabs_MouseClick(object sender, MouseEventArgs e)
        {
            if (floater != null) floater.scramble();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void moFl1_Click(object sender, EventArgs e)
        {
            GraphFloater.length += 10;
            moFl1.Enabled = GraphFloater.length < Math.Min(PB.Width, PB.Height) / 2;
            moFl2.Enabled = GraphFloater.length > 20;
        }

        private void moFl2_Click(object sender, EventArgs e)
        {
            GraphFloater.length -= 10;
            moFl1.Enabled = GraphFloater.length < Math.Min(PB.Width, PB.Height) / 2;
            moFl2.Enabled = GraphFloater.length > 20;
        }

        private void moFl3_Click(object sender, EventArgs e)
        {
            GraphFloater.delay -= 10;
            moFl3.Enabled = GraphFloater.delay > 20;
            moFl4.Enabled = GraphFloater.delay < 1000;
        }

        private void moFl4_Click(object sender, EventArgs e)
        {
            GraphFloater.delay += 10;
            moFl3.Enabled = GraphFloater.delay > 20;
            moFl4.Enabled = GraphFloater.delay < 1000;
        }

        private void moFl5_Click(object sender, EventArgs e)
        {
            GraphFloater.k += 0.05f;
            moFl5.Enabled = GraphFloater.k < 1;
            moFl6.Enabled = GraphFloater.k > 0.1f;
        }

        private void moFl6_Click(object sender, EventArgs e)
        {
            GraphFloater.k -= 0.05f;
            moFl5.Enabled = GraphFloater.k < 1;
            moFl6.Enabled = GraphFloater.k > 0.1f;
        }

        private void moFl7_Click(object sender, EventArgs e)
        {
            GraphFloater.length = GraphFloater.LENGTH;
            GraphFloater.k = GraphFloater.K;
            GraphFloater.delay = GraphFloater.DELAY;
            moFl1.Enabled = true;
            moFl2.Enabled = true;
            moFl3.Enabled = true;
            moFl4.Enabled = true;
            moFl5.Enabled = true;
            moFl6.Enabled = true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void mtComponents_Click(object sender, EventArgs e)
        {
            g.findConnectedComponents();
            MessageBox.Show("The number of " + ((g.oriented) ? "strongly " : "") + "connected components is: " + g.components, "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mtCyclomatic_Click(object sender, EventArgs e)
        {
            g.findConnectedComponents();
            MessageBox.Show("The cyclomatic number of a graph is: \n[nr.edges]-[nr.vertices]+[nr.(Strongly)ConnectedComponents]. \nFor the current graph: " + g.edges.Count + " - " + g.vertices.Count + " + " + g.components + " = " + (g.edges.Count - g.vertices.Count + g.components), "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mtEqual_Click(object sender, EventArgs e)
        {
            Input input = new Input(g, "Specify path length and source && destination vertices.\nLarge numbers may cause overflow.", Input.TYPE_COMBO);
            if (input.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    short nr = short.Parse(input.input);
                    if (nr > 0)
                    {
                        Matrix matrix = g.getMatrix().power(nr);
                        if (matrix != null)
                            MessageBox.Show("The number of paths of length " + nr + " \nbetween [" + (input.src + 1) + "]" + ((Vertex)g.vertices[input.src]).name + " and [" + (input.dst + 1) + "]" + ((Vertex)g.vertices[input.dst]).name + " is: " + matrix.m[input.src, input.dst], "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Path length too large! Arithmetic overflow.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Please specify a strictly positive integer.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Please specify a strictly positive integer less than 30,000.\n" + err.Message, "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void mtLess_Click(object sender, EventArgs e)
        {
            Input input = new Input(g, "Specify maximum path length \nand source && destination vertices.\nLarge numbers may cause overflow.", Input.TYPE_COMBO);
            if (input.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    short nr = short.Parse(input.input);
                    if (nr > 0)
                    {
                        Matrix matrix = g.getMatrix().powersum(stats.Panels[0], nr);
                        if (matrix != null)
                            MessageBox.Show("The number of paths of length less or equal to " + nr + " \nbetween [" + (input.src + 1) + "]" + ((Vertex)g.vertices[input.src]).name + " and [" + (input.dst + 1) + "]" + ((Vertex)g.vertices[input.dst]).name + " is: " + matrix.m[input.src, input.dst], "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Path length too large! Arithmetic overflow.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        stats.Panels[0].Text = g.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Please specify a strictly positive integer.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Please specify a strictly positive integer less than 30,000.\n" + err.Message, "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void mtCrRandomP_Click(object sender, EventArgs e)
        {
            Input input = new Input(g, "Specify a number of vertices between 1 and 30.", Input.TYPE_TEXT);
            if (input.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    byte nr = byte.Parse(input.input);
                    if (nr > 0 && nr < 31)
                        addGraph(new Graph(null, PB.Width, PB.Height, nr, Graph.TYPE_PGRAPH));
                    else
                        MessageBox.Show("Please specify an integer between 1 and 30.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Please specify an integer between 1 and 30.\n" + err.Message, "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void mtCrRandom1_Click(object sender, EventArgs e)
        {
            Input input = new Input(g, "Specify a number of vertices between 1 and 60.", Input.TYPE_TEXT);
            if (input.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    byte nr = byte.Parse(input.input);
                    if (nr > 0 && nr < 61)
                        addGraph(new Graph(null, PB.Width, PB.Height, nr, Graph.TYPE_1GRAPH));
                    else
                        MessageBox.Show("Please specify an integer between 1 and 60.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Please specify an integer between 1 and 60.\n" + err.Message, "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void mtCrComplete_Click(object sender, EventArgs e)
        {
            Input input = new Input(g, "Specify a number of vertices between 1 and 20.", Input.TYPE_TEXT);
            if (input.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    byte nr = byte.Parse(input.input);
                    if (nr > 0 && nr < 21)
                        addGraph(new Graph(null, PB.Width, PB.Height, nr, Graph.TYPE_COMPLETE));
                    else
                        MessageBox.Show("Please specify an integer between 1 and 20.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Please specify an integer between 1 and 20.\n" + err.Message, "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void mtCrInfo_Click(object sender, EventArgs e)
        {
            Input input = new Input(g, "Write the maximum string allowed.\nOnly small letters allowed. \"e\" fills with empty string.\n(eg: \"fa\" fills each edge with two letters first not greater than 'f' and second being 'a')", Input.TYPE_TEXT);
            if (input.ShowDialog(this) == DialogResult.OK)
            {
                String s = input.input.Replace(" ", "");
                bool valid = s.Length > 0;
                for (int i = 0; i < s.Length; i++) if ('a' > s[i] || 'z' < s[i]) valid = false;
                if (valid)
                {
                    Graph graph = new Graph(g, Graph.CLONE_ORIGINAL);
                    foreach (Edge edge in graph.edges)
                    {
                        if (edge.name == null || edge.name.Equals(""))
                        {
                            if (s.Equals("e"))
                                edge.name = "e";
                            else
                            {
                                edge.name = "";
                                for (int i = 0; i < s.Length; i++)
                                {
                                    char c = (char) rnd.Next('a', s[i] + 1);
                                    if (c == 'e') c = 'd';
                                    edge.name += c.ToString();
                                }
                            }
                        }
                    }
                    addGraph(graph);
                }
                else
                    MessageBox.Show("Please specify a valid string. ", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void mtCrNo_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph(g, Graph.CLONE_ORIGINAL);
            foreach (Edge edge in graph.edges) edge.name = "";
            addGraph(graph);
        }

        private void mtCrWeight_Click(object sender, EventArgs e)
        {
            Input input = new Input(g, "Write the maximum weight allowed.\nNon-integer number produces decimal weights.\nNegative number produces weights of modulus \nless or equal to its modulus.", Input.TYPE_TEXT);
            if (input.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    double nr = double.Parse(input.input);
                    Graph graph = new Graph(g, Graph.CLONE_ORIGINAL);
                    foreach (Edge edge in graph.edges)
                    {
                        if (edge.name != null && !edge.name.Equals("")) continue;
                        if ((long) nr == nr)
                        {
                            edge.name = (long)(rnd.NextDouble() * (Math.Abs(nr) + 1)) + "";
                        }
                        else
                        {
                            double w = rnd.NextDouble() * Math.Abs(nr);
                            edge.name = w.ToString("0.000");
                        }
                        if (nr < 0)
                        {
                            if (rnd.NextDouble() < 0.5 && !edge.name.Equals("0")) edge.name = "-" + edge.name;
                        }
                    }
                    addGraph(graph);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Please specify a number.\n" + err.Message, "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
 
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void mtCvNonP_Click(object sender, EventArgs e)
        {
            if (!g.oriented)
            {
                MessageBox.Show("Cannot convert because current graph is not directed.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            addGraph(new Graph(g, Graph.CLONE_PGRAPH));
        }

        private void mtCvNon1_Click(object sender, EventArgs e)
        {
            if (!g.oriented)
            {
                MessageBox.Show("Cannot convert because current graph is not directed.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            addGraph(new Graph(g, Graph.CLONE_1GRAPH));
        }

        private void mtCvOr_Click(object sender, EventArgs e)
        {
            if (!g.oriented)
            {
                MessageBox.Show("Cannot convert because current graph is not directed.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            addGraph(new Graph(g, Graph.CLONE_ORIENTED));
        }

        private void mtCvOrDouble_Click(object sender, EventArgs e)
        {
            if (g.oriented)
            {
                MessageBox.Show("Cannot convert because current graph is already directed.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            addGraph(new Graph(g, Graph.CLONE_DOUBLE));
        }

        private void mtCvOrRandom_Click(object sender, EventArgs e)
        {
            if (g.oriented)
            {
                MessageBox.Show("Cannot convert because current graph is already directed.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            addGraph(new Graph(g, Graph.CLONE_RANDOM));
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void mtBuild_Click(object sender, EventArgs e)
        {
            addGraph(g.getComponentGraph(PB.Width, PB.Height));
        }

        private void mtNondeterministic_Click(object sender, EventArgs e)
        {
            Input input = new Input(g, "Write the accepted language. \nOnly small letters && (,),*,U are accepted. \n'e' is empty string, '*' and 'U' are Kleene star \nand union operators. Concatenation is implicit.", Input.TYPE_TEXT);
            if (input.ShowDialog(this) == DialogResult.OK)
                if (Tree.check(input.input))
                {
                    addGraph(AutomataBuilder.getNondeterministicAutomaton(input.input, PB.Width, PB.Height));
                }
                else
                {
                    MessageBox.Show("Please specify a valid accepted language.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
        }

        private void mtDeterministic_Click(object sender, EventArgs e)
        {
            if (g.isAutomaton() && !g.isDeterministic())
            {
                Graph det = AutomataBuilder.getDeterministicAutomaton(g, PB.Width, PB.Height);
                foreach (Vertex v in det.vertices)
                    if (v.name.Equals("Null"))
                    {
                        v.pos = new PointF(PB.Width / 2, PB.Height / 2);
                        det.setAllPoints();
                        break;
                    }
                addGraph(det);
            }
            else
            {
                MessageBox.Show("Current graph is not a non-deterministic automaton. ", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void mtShort_Click(object sender, EventArgs e)
        {
            Input input = new Input(g, "Specify source and destination vertices.", Input.TYPE_VERTICES);
            if (input.ShowDialog(this) == DialogResult.OK)
            {
                if (input.src != input.dst)
                {
                    Vertex src = (Vertex) g.vertices[input.src];
                    Vertex dst = (Vertex) g.vertices[input.dst];

                    g.BFS_explore(src);

                    if (dst.distance < 0)
                        MessageBox.Show("The two vertices are not connected. ", "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        g.clearTechInfo();
                        Vertex current = dst;
                        current.tech_name = "{" + current.distance + "}";
                        while (current.parentV != null)
                        {
                            current.parentV.tech_name = "{" + current.parentV.distance + "}";
                            Edge marked = null;
                            foreach (Edge edge in current.parentV.edges)
                                if ((edge.src == current.parentV && edge.dst == current) || (!g.oriented && edge.src == current && edge.dst == current.parentV))
                                    marked = edge;
                            marked.tech_color = EDGE_TECHNICAL;
                            current = current.parentV;
                        }
                        hover_edge = null;
                        hover_vert = null;
                        tech_info = true;
                        PB.Refresh();
                        MessageBox.Show("Shortest path has been marked in red.\nLength is: " + dst.distance, "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tech_info = false;
                        PB.Refresh();
                    }
                }
                else
                    MessageBox.Show("Please specify source & destination vertices different to eachother.", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void mtTree_Click(object sender, EventArgs e)
        {
            if (g.oriented)
            {
                MessageBox.Show("Graph must be undirected!", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (!g.setWeights())
            {
                MessageBox.Show("Not all edge weights are numbers!", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            g.findConnectedComponents();
            g.edges.Sort();
            g.clearTechInfo();
            for (int c = 1; c <= g.components; c++)
            {
                ArrayList comp_tree = g.getMinSpanTree(c);
                foreach (Edge edge in comp_tree) edge.tech_color = EDGE_TECHNICAL;
            }
            foreach (Vertex v in g.vertices) v.tech_name = "[" + (v.index + 1) + "] " + v.name;
            hover_edge = null;
            hover_vert = null;
            tech_info = true;
            PB.Refresh();
            MessageBox.Show("Minimum spanning tree for each connected \ncomponent has been marked in red.\nNo specified edge weight means unit weight.", "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tech_info = false;
            PB.Refresh();
        }

        private void mtCluster_Click(object sender, EventArgs e)
        {
            if (g.vertices.Count <= 1)
            {
                MessageBox.Show("Add more vertices first.", "*** Not enough points", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Input input = new Input(g, "Specify the number of clusters.", Input.TYPE_TEXT);
            if (input.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    int nr = int.Parse(input.input);
                    if (nr >= 1 && nr <= g.vertices.Count)
                    {
                        g.findKClustering(nr);
                        g.clearTechInfo();
                        foreach (Vertex v in g.vertices) v.tech_name = "[" + (v.index + 1) + "](" + (int)v.pos.X + "," + (int)v.pos.Y + ")~K" + v.cluster;
                        hover_vert = null;
                        hover_edge = null;
                        tech_info = true;
                        no_edges = true;
                        PB.Refresh();
                        MessageBox.Show("Maximum spacing " + nr + "-clustering has been computed.\nMinimum spacing between clusters is: " + g.spacing.ToString("#.000;;Zero") + "\nTotal spacing between clusters is: " + g.total_spacing.ToString("#.000;;Zero"), "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tech_info = false;
                        no_edges = false;
                        PB.Refresh();
                    }
                    else
                        MessageBox.Show("Please specify an integer between 1 and " + g.vertices.Count + ".", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Please specify an integer between 1 and " + g.vertices.Count + ".\n" + err.Message, "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void mtMinimum_Click(object sender, EventArgs e)
        {
            Input input = new Input(g, "Specify source vertex.", Input.TYPE_SOURCE);
            if (input.ShowDialog(this) != DialogResult.OK) return;
            if (!g.setWeights())
            {
                MessageBox.Show("Not all edge weights are numbers!", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (!g.singleSource((Vertex) g.vertices[input.src]))
            {
                if (!g.oriented)
                    MessageBox.Show("No negative edge weights allowed for current undirected graph!", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    MessageBox.Show("Current graph contains a negative weight cycle!", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            g.clearTechInfo();
            foreach (Vertex v in g.vertices)
            {
                if (v.cost < double.MaxValue) v.tech_name = "{" + v.cost.ToString("0.###") + "}";
                if (v.parentE != null) v.parentE.tech_color = EDGE_TECHNICAL;
            }
            hover_edge = null;
            hover_vert = null;
            tech_info = true;
            PB.Refresh();
            MessageBox.Show("All single-source minimum cost paths have been marked in red.\nEach reachable vertex has been marked with its reaching cost.\nNo specified edge weight means unit weight.", "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tech_info = false;
            PB.Refresh();
        }

        private void mtFinal_Click(object sender, EventArgs e)
        {
            if (g.isAutomaton() && g.isDeterministic())
            {
                Input input = new Input(g, "Specify input string.\nOnly letters in the automaton alphabet allowed.", Input.TYPE_TEXT);
                if (input.ShowDialog(this) == DialogResult.OK)
                {
                    String s = input.input.Replace(" ","").Replace("e","");
                    for (int i = 0; i < s.Length; i++)
                        if (g.alphabet.IndexOf(s[i])<0)
                        {
                            MessageBox.Show("Please specify a valid input string.","*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    g.clearTechInfo();
                    Vertex curV = null;
                    foreach (Vertex v in g.vertices) if (v.is_start) curV = v;
                    curV.tech_name = "{0}";
                    for (int i = 0; i < s.Length; i++)
                    {
                        foreach (Edge edge in curV.edges)
                        {
                            if (edge.src == curV && edge.name.IndexOf(s[i])>=0)
                            {
                                edge.tech_color = EDGE_TECHNICAL;
                                curV = edge.dst;
                                curV.tech_name += "{" + (i + 1) + "}";
                                break;
                            }
                        }
                    }
                    hover_edge = null;
                    hover_vert = null;
                    tech_info = true;
                    PB.Refresh();
                    if (curV.is_finish)
                        MessageBox.Show("\"" + s + "\"" + " is an accepted string. ","*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    else
                        MessageBox.Show("\"" + s + "\"" + " is NOT an accepted string. ","*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    tech_info = false;
                    PB.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Current graph is not a deterministic automaton. ","*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void mtMark_Click(object sender, EventArgs e)
        {
            g.markEdges();
            hover_edge = null;
            hover_vert = null;
            tech_info = true;
            PB.Refresh();
            MessageBox.Show("All Depth-First Search trees have been found.\nVertices have been marked with:\n  * vertex index\n  * DFS stack add time\n  * DFS stack remove time\n  * depth in DFS tree\nEdges have been colored as follows:\n  * RED - DFS tree edge\n  * GREEN - forward edge\n  * VIOLET - back edge\n  * BLACK - cross edge", "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tech_info = false;
            PB.Refresh();
        }

        private void mtEuler_Click(object sender, EventArgs e)
        {
            if (g.oriented)
            {
                MessageBox.Show("Graph must be undirected!", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Input input = new Input(g, "Specify source and destination vertices \nbelonging to the same connected component.\nSelecting the same vertex yields an Euler tour.", Input.TYPE_VERTICES);
            if (input.ShowDialog(this) != DialogResult.OK) return;
            g.findConnectedComponents();
            Vertex source = (Vertex)g.vertices[input.src];
            Vertex destination = (Vertex)g.vertices[input.dst];
            if (source.component != destination.component)
            {
                MessageBox.Show("The two vertices must be in the same connected component!", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            ArrayList path = g.getEulerPath(source, destination);
            if (path == null)
            {
                MessageBox.Show("There is NO Euler path between the selected vertices.", "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            g.clearTechInfo();
            for (int i = path.Count - 1; i >= 0; i--)
            {
                Vertex v = (Vertex)g.vertices[(int)path[i]];
                if (v.tech_name.Equals(" ")) v.tech_name = "";
                v.tech_name += "{" + (path.Count - 1 - i) + "}";
            }
            hover_edge = null;
            hover_vert = null;
            tech_info = true;
            PB.Refresh();
            MessageBox.Show("Vertices along the Euler path have been marked \nwith their index in the path.", "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tech_info = false;
            PB.Refresh();
        }

        private void mtEulerTwo_Click(object sender, EventArgs e)
        {
            if (g.oriented)
            {
                MessageBox.Show("Graph must be undirected!", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Input input = new Input(g, "Specify source vertex for two-way Euler tour.", Input.TYPE_SOURCE);
            if (input.ShowDialog(this) != DialogResult.OK) return;
            ArrayList tour = g.getTwoWayEulerTour((Vertex)g.vertices[input.src]);
            g.clearTechInfo();
            for (int i = 0; i < tour.Count; i++)
            {
                Vertex v = (Vertex)tour[i];
                if (v.tech_name.Equals(" ")) v.tech_name = "";
                v.tech_name += "{" + i + "}";
            }
            hover_edge = null;
            hover_vert = null;
            tech_info = true;
            PB.Refresh();
            MessageBox.Show("Vertices along the two-way Euler tour have been marked \nwith their index in the tour.", "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tech_info = false;
            PB.Refresh();
        }

        private void mtBipartite_Click(object sender, EventArgs e)
        {
            if (g.oriented)
            {
                MessageBox.Show("Graph must be undirected!", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (!g.isBipartite())
            {
                MessageBox.Show("Current graph is NOT bipartite.", "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            g.clearTechInfo();
            foreach (Vertex v in g.vertices)
                v.tech_name = "[" + (v.index + 1) + ((v.color == Vertex.BLACK) ? "](B)" : "](W)");
            hover_edge = null;
            hover_vert = null;
            tech_info = true;
            PB.Refresh();
            MessageBox.Show("Graph is bipartite.\nVertices have been marked with 'Black' or 'White'.", "*** Computation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tech_info = false;
            PB.Refresh();
        }
        
        private void mtArticulation_Click(object sender, EventArgs e)
        {

        }

        private void mtMinimize_Click(object sender, EventArgs e)
        {
            if (g.isAutomaton() && g.isDeterministic())
            {
                Graph min = AutomataBuilder.getMinimalAutomaton(g, PB.Width, PB.Height);
                foreach (Vertex v in min.vertices)
                    if (v.name.Equals("Null"))
                    {
                        v.pos = new PointF(PB.Width / 2, PB.Height / 2);
                        min.setAllPoints();
                        break;
                    }
                addGraph(min);
            }
            else
            {
                MessageBox.Show("Current graph is not a deterministic automaton. ", "*** Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void mmNothing_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Graph Tool v2.1\nby Alexandru Stefanescu\nMay 2009\n\nThis little app is designed to help you understand automaton " +
                "and graph algorithms by providing a visual model.\n\nSend comments to: axel_kosmo@yahoo.com", "*** About", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}