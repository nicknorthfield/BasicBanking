/*
 * Created by SharpDevelop.
 * User: Y7NNORTH
 * Date: 22/07/2016
 * Time: 13:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BasicBanking3
{
	public class BankingApp
	{
		private BankingApp()
		{
			
		}
		
		public BankingApp(string one, decimal other)
		{
			
		}
	}
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		private decimal totalIn_2;
		private decimal totalOut_2;

		
		public decimal totalIn2
		{
			get { return totalIn_2; }
		}
		
		public decimal totalOut2
		{
			get { return totalOut_2; }
		}

		
		void BrowseButtonClick(object sender, EventArgs e)
		{
			ChooseFolder();
		}
		
		
		void RunButtonClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(inputFileLocationTextBox.Text)) {
				MessageBox.Show("Please select a file using the Browse button");
			}
			else {
				try {
				GetBankingData();	
				}
				//catch (Exception err) {		// Generic error, needs to be specific to the problem at hand, i.e. the file is already open
				catch (FileNotFoundException) {
					MessageBox.Show("Filters file is missing. Please create Filters.txt in the same folder " +
					                "that this program is being run from and populate it with rows containing generic " +
					                "identifiers and pipe delimited strings separated by commas.");
				}
				catch (IOException err) {
					MessageBox.Show("The file may be open, please close and try running the program again."  + err);
				}
				catch (System.Exception err2) {
					MessageBox.Show("Unknown error    :("  + err2);
				}

			}
		}
        // TO-DO
        // Release code and make it work with relative paths...
        // Refactor the code - it looks awful at the moment
        // Use Getters and Setters for a start
        // See code snippets in 
        // C:\Users\Y7NNORTH\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1
        // and 
        // C:\Users\Y7NNORTH\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1TestsXX
        // for an application that can be unit tested
        // GetBankingData is way too big, needs to all be separated out into smaller methods

        // This code cannot be unit tested at the moment as all business logic resides in the form. Follow this link: -
        // http://stackoverflow.com/questions/9097044/advice-on-unit-testing-a-windows-forms-application
        // Need to separate the business logic from the form to make it all testable, e.g.

        //  buttonclick += (o,e)=> {/*somecode*/};
        //      is very hard to test.

        //  private void button1_Click(object sender, EventArgs e) {/*somecode*/}
        //      still hard to test

        //  public void button1_Click(object sender, EventArgs e) {/*somecode*/}
        //      easier to test

        //  private void button1_Click(object sender, EventArgs e) { DoSave(); }
        //  public void DoSave() {/*somecode*/}
        //      Really easy to Test!

        //      This goes double if you need some information from the event. ie.

        //  public void ZoomInto(int x, int y)
        //      is much easier to test that the corresponding mouse click event, and the passthrough call can still be a single ignorable line.

        public void ChooseFolder() {
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				inputFileLocationTextBox.Text = openFileDialog1.FileName;
			}
		}
		

		public void GetBankingData() {
			
			string currentDir = Environment.CurrentDirectory;
			DirectoryInfo directory = new DirectoryInfo(currentDir);
		//	FileInfo file = new FileInfo(args[0]);
			
			string fullDir = directory.FullName;
		//	string fullName = file.FullName;
			
			
			
			spendsListBox.Items.Clear();
			otherListBox.Items.Clear();
			
		//	otherListBox.Items.Add(fullDir);
		//	otherListBox.Items.Add(fullName);
		// Get date from file and create string to represent date - "June 2016"
       //   treeView1.Nodes.Add("May 2016"); // example node data - need to get actual data from file

		// Get banking data from file and place in a 2D array
		//var bankingData = File.ReadAllLines(@"H:\Personal\Coding\00432174_20160606_1959.csv");

		var bankingData = File.ReadAllLines(@inputFileLocationTextBox.Text);

		
		// Find number of columns in file (looks for comma delimiter so need to add 1 to get correct value
		int NoOfBDColumns = bankingData[0].Split(',').Length - 1;
		int NoOfBDRows = bankingData.Length;

		// Create array to hold all values from the text file
		string[,] bankingDataArray = new string[NoOfBDColumns + 3,bankingData.Length];
		
			// data will be arranged in dataArray: -
			// 			[0,x]				[1,x]				[2,x]		[3,x]			[4,x]							[5,x]			[6,x]			[7,x]
			// [x,0]	Transaction Date	Transaction Type	Sort Code	Account Number	Transaction Description			Debit Amount	Credit Amount	Balance
			// [x,1]	31/05/2016			DEB					11-22-33	12341234		CENTRAL CO-OP RETA CD 0724		47.58							79.89
			// [x,2]	31/05/2016			DEB					11-22-33	12341234		Amazon UK Retail CD 0724		12.67							127.47
			// [x,3]	31/05/2016			BGC					11-22-33	12341234		Acme PLC										666.13			140.14
			// etc...
		
		// Populate the array
		
		int rowCount = 0;
		int columnCount = 0;
		try {
			foreach (var row in bankingData) {
				columnCount = 0;
				foreach (var column in row.Trim().Split(',')) {
					bankingDataArray[columnCount,rowCount] = column;
					columnCount++;
				}
				rowCount++;
			}
		} catch (Exception e) {
		//	file.WriteLine(e);
			otherListBox.Items.Add(e);
		}
		
		
		// Get data range from the input file
		string startDate = bankingDataArray[0,bankingData.Length - 1];
		string endDate = bankingDataArray[0, 1];
		
		
		// Get filter data from file and place in a 2D array
		var filterData = File.ReadAllLines(@".\Filters.txt");
		int noOfFDColumns = filterData[0].Split(',').Length - 1;
		int noOfFDRows = filterData.Length;
		string[,] filterDataArray = new string[noOfFDColumns + 1, filterData.Length];
		
		// Data will be arranged in the array as [first value,second value]
		rowCount = 0;
		columnCount = 0;
		foreach (var row in filterData) {
			columnCount = 0;
			foreach (var column in row.Trim().Split(',')) {
				filterDataArray[columnCount,rowCount] = column;
				columnCount++;
			}
			rowCount++;
		}
		
		// Open streamwriter for writing output to file
		System.IO.StreamWriter file = new System.IO.StreamWriter(@".\Output.txt");
			
		// GET TOTALS
		
		// get totalIn
		decimal totalIn = 0;
		for (int i = 1; i < bankingData.Length; i++) {
			if ((bankingDataArray[5, i]) != "") {
				totalIn = totalIn + decimal.Parse(bankingDataArray[5, i]);
			}
		}
	
	
		// get totalOut
		decimal totalOut = 0;
		for (int i = 1; i < bankingData.Length; i++) {
			if ((bankingDataArray[6, i]) != "") {
				totalOut = totalOut + decimal.Parse(bankingDataArray[6, i]);
			}
		}
		
		// Output date range
		if (saveToFileCheckbox.Checked) {
			file.WriteLine("Date of first transaction = " + startDate);
			file.WriteLine("Date of last transaction = " + endDate);
			file.WriteLine("");
		}
		spendsListBox.Items.Add("Date of first transaction = " + startDate);
		spendsListBox.Items.Add("Date of last transaction = " + endDate);
		spendsListBox.Items.Add("");
		
		
		// WRITE ALL RESULTS TO FILE
		if (saveToFileCheckbox.Checked) {
			file.WriteLine("Start balance = " + bankingDataArray[7, bankingData.Length - 1]);
			file.WriteLine("Final balance = " + bankingDataArray[7, 1]);		
			file.WriteLine("Total in = " + totalIn);
			file.WriteLine("Total out = " + totalOut);	
			file.WriteLine("");
		}
		spendsListBox.Items.Add("Start balance = " + bankingDataArray[7, bankingData.Length - 1]);
		spendsListBox.Items.Add("Final balance = " + bankingDataArray[7, 1]);		
		spendsListBox.Items.Add("Total in = " + totalIn);
		spendsListBox.Items.Add("Total out = " + totalOut);
		spendsListBox.Items.Add("");
		
		
		// Get user defined totals
		
		decimal totalUserDefined = 0;
		decimal totalValueAccountedFor = 0;
		int pipeDelimQuantity = 0;
		bool hasDelims = false;
		bool gotDelims = false;
		string temp = "";
		int delimCount = 0;
		for (int i = 0; i < filterData.Length; i++) {
			// get number of pipe delimited values in second element - now what to do with this info
			pipeDelimQuantity = (filterDataArray[1, i].Split('|').Length - 1) + 1;
			string[] tempArray = new string[pipeDelimQuantity];
			if (pipeDelimQuantity > 1) {
				hasDelims = true;
			}
			// Populate tempArray with values from delimiter separated array entry
			if (hasDelims) {
				int itemCount = 0;
				foreach (var item in filterDataArray[1, i].Trim().Split('|')) {
					tempArray[itemCount] = item;
					itemCount++;
				}
				gotDelims = true;
			}

			
			while (pipeDelimQuantity > 0) {
				// loop through each element of the second column
				if (gotDelims) {
					temp = tempArray[delimCount];
					delimCount++;
				}
				else {
					temp = filterDataArray[1, i];
				}
				for (int j = 1; j < bankingData.Length; j++) {
					// Check each element in column 4 for the flag then temp then add total
					if (bankingDataArray[4,j].Contains(temp)) {
					   // file.WriteLine("Test - i = " + i + " - j = " + j); // DEBUG
					    if(bankingDataArray[8, j] != "USED") {
					   		// =================================================
					   		// At this point I need to cater for credits as well.
					   		// The current always assumes debit
					   		// Run new export ..._1250.csv and it will fail as soon as it encounters 
					   		// the first NORTHFIELD as this is a credit
					   		// Need to fully refactor this project, use seperate methods for debit, credit, balance, etc
					   		// =================================================
					    	totalUserDefined = totalUserDefined + decimal.Parse(bankingDataArray[5, j]);
					    	bankingDataArray[9, j] = filterDataArray[0, i];
					    	bankingDataArray[10, j] = temp; // not working at the moment
					    	bankingDataArray[8, j] = "USED";
					    }
					}
				}
			//	treeView1.Nodes[0].Nodes[0].Nodes.Add(temp); // Not sure what this is doing apart from giving all
				pipeDelimQuantity--;
			}
			if (saveToFileCheckbox.Checked) {
				file.WriteLine("Total spent on " + filterDataArray[0, i] + " was £" + totalUserDefined);
			}
			spendsListBox.Items.Add("£" + totalUserDefined + "\t\tTotal spent on " + filterDataArray[0, i]);
			totalValueAccountedFor = totalValueAccountedFor + totalUserDefined;
	//		treeView1.Nodes[0].Nodes.Add(bankingDataArray[8, ]);
			totalUserDefined = 0;
			delimCount = 0;
		}
		
		
		// Need to look at column 8 and state that there are x number of rows not accounted for totalling £y
		// Add more entries to Filters.txt to account for the mising rows
		int unusedItemCount = 0;
		bool unusedItemsPresent = false;
		for (int i = 0; i < bankingData.Length; i++) {
			if (bankingDataArray[8, i] == null) {
				unusedItemCount++;
				unusedItemsPresent = true;
			}
		}
		if (saveToFileCheckbox.Checked) {
			file.WriteLine("Total balance accounted for = £" + totalValueAccountedFor);
		}
		decimal totalValueNotAccountedFor = totalIn - totalValueAccountedFor;
		
		if (unusedItemsPresent) {
			
			file.WriteLine("");
			if (unusedItemCount == 1) {
				if (saveToFileCheckbox.Checked) {
					file.WriteLine("There is " + unusedItemCount + " item worth £" + totalValueNotAccountedFor + " unaccounted for. Please add more references to Filters.txt");
				}
				otherListBox.Items.Add("There is " + unusedItemCount + " item worth £" + totalValueNotAccountedFor + " unaccounted for. Please add more references to Filters.txt");
			} else {
				if (saveToFileCheckbox.Checked) {
					file.WriteLine("There are " + unusedItemCount + " items worth £" + totalValueNotAccountedFor + " unaccounted for. Please add more references to Filters.txt");
				}
				otherListBox.Items.Add("There are " + unusedItemCount + " items worth £" + totalValueNotAccountedFor + " unaccounted for. Please add more references to Filters.txt");
			}
			if (saveToFileCheckbox.Checked) {
				file.WriteLine("These are: -");
				file.WriteLine("");
			}
			
			otherListBox.Items.Add("These are: -");
			otherListBox.Items.Add("");
			// Write out all unused items
			for (int i = 0; i < bankingData.Length; i++) {
				if (bankingDataArray[8, i] == null) {
					if (saveToFileCheckbox.Checked) {
						file.WriteLine(bankingData[i]);
					}
					otherListBox.Items.Add(bankingData[i]);
			//		treeView1.Nodes.Add(bankingData[i]);
				}
			}
			
		}

		// Close StreamWriter		
		file.Close();

		}
	}
}
