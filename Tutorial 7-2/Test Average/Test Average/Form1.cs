using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The Average method accepts an int array argument
        // and returns the Average of the values in the array.
        private double Average(int[] iArray)
        {
            int total = 0;   // Accumulator, initialized to 0
            double average;  // To hold the average

            // Step through the array, adding each element to
            // the accumulator. 
            for (int index = 0; index < iArray.Length; index++)
            {
                total += iArray[index];
            }

            // Calculate the average.
            average = (double) total / iArray.Length;

            // Return the average.
            return average;
        }

        // The Highest method accepts an int array argument
        // and returns the highest value in that array.
        private int Highest(int[] iArray)
        {
            // Declare a variable to hold the highest value, and
            // initialize it with the first value in the array.
            //MWB_1/23/2019
            int highest = iArray[0];

            // Step through the rest of the array, beginning at
            // element 1. When a value greater than highest is found,
            // assign that value to highest.
            //-MWB_1/23/2019
            for(int index = 1; index < iArray.Length; index++)
            {
                if (highest < iArray[index])
                {
                    highest = iArray[index];
                }
            }

            // Return the highest value.
            //-MWB_1/23/2019
            return highest;
        }

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        private int Lowest(int[] iArray)
        {
            // Declare a variable to hold the lowest value, and
            // initialize it with the first value in the array.
            //-MWB_1/23/2019
            int lowest = iArray[0];

            // Step through the rest of the array, beginning at
            // element 1. When a value less than lowest is found,
            // assign that value to lowest.
            //-MWB_1/23/2019
            for (int index = 1; index < iArray.Length; index++)
            {
                if (lowest > iArray[index])
                {
                    lowest = iArray[index];
                }
            }

            // Return the lowest value.
            //-MWB_1/23/2019
            return lowest;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Local variables
                const int SIZE = 5;            // Number of tests
                int index = 0;                 // Loop counter
                int score;                     // To hold one score 
                int highestScore;              // To hold the highest score
                int lowestScore;               // To hold the lowest score
                double averageScore;           // To hold the average score
                StreamReader inputFile;        // For file input

                // TODO:  declare a variable, scores, that will store 5 integers
                //MWB_1/23/2019
                int[] scores = new int[SIZE];

                // Open the file and get a StreamReader object.
                inputFile = File.OpenText("TestScores.txt");

                // Read the test scores into the array.
                while ((!inputFile.EndOfStream) && (index < SIZE))
                {
                    // TODO:  read a line from the file, convert to int put in score 
                    // put score in the array at the current index
                    // increment the index
                    //-MWB_1/23/2019
                    score = int.Parse(inputFile.ReadLine());
                    scores[index] = score;
                    index++;
                }

                // Close the file.
                inputFile.Close();

                // iterate through the array using a foreach loop
                // and add one item at a time to the listbox
                //"s" is an index, I was originally misusing the foreach loop -MWB_1/24/2019
                foreach (int s in scores)
                    testScoresListBox.Items.Add(s);

                // Get the highest, lowest, and average scores.
                // Use the methods
                //-MWB_1/23/2019
                highestScore = Highest(scores);
                lowestScore = Lowest(scores);
                averageScore = Average(scores);

                // Display the values, highest, lowest and average 
                //-MWB_1/23/2019
                highScoreLabel.Text = highestScore.ToString();
                lowScoreLabel.Text = lowestScore.ToString();
                averageScoreLabel.Text = averageScore.ToString();

            }
            catch (Exception ex)
            {
                // Display an error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
