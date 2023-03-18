using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListLecture
{//EDNA LYNN LAXA 
 //MARCH 1, 2023 
 //LIST LECTURE 
 //CSI - PROGRAMMING II 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] firstNames = { "Summer", "Springly", "Fallalina", "Winter" };
        string[] lastNames = { "June", "April", "September", "December" };
        int[] grades = { 100, 90, 95, 50 };

        string[] newFirstNames;

        //KEYWORD LIST <T> ; T IS GENERIC - REPRESENTS ANY TYPE AVAILABLE 
        List<string> firstNamesList = new List<string> { "Summer", "Springly", "Fallalina", "Winter" };
        List<string> lastNamesList;
        List<int> gradeList;
        List<StackPanel> panels = new List<StackPanel>(); 

        public MainWindow()
        {
            InitializeComponent();
            

            lastNamesList = lastNames.ToList();
            gradeList = grades.ToList();

            panels.Add(SPAddStudent);
            panels.Add(SPInsert);
            panels.Add(SP3_);

            panels[0].Visibility = Visibility.Visible;

          
    

            DisplayFromList();
         
          

        }
        public void HidePanels()
        {
            for (int i = 0; i < panels.count; i++)
            {
                panels[i].Visibility = Visibility.Hidden;
            }
        }
        //HIDE ALL PANELS 
        public void DisplayFromList()
        {
            runDisplay.Text = "";
            for (int i = 0; i < firstNamesList.Count; i++)
            {
                
                FormatString(i); 
            }
            //runDisplay.Text += firstNamesList[i] + "\n"; //REPLACED W/ Method FormatString. 

        }

        public void FormatString(int i)
        {
            //string fName = firstNamesList[i];
            //string lName = lastNamesList[i];
            //int grades = gradeList[i];

            runDisplay.Text += $"{i} - {firstNamesList[i]} {lastNamesList[i]} - {gradeList[i]}\n";

        }
        private void btn_AddStudent_Click(object sender, RoutedEventArgs e)
        {

            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            int grade = int.Parse(txtGrade.Text);

            //To add to a list  = .ADD 
            firstNamesList.Add(fName);
            lastNamesList.Add(lName);
            gradeList.Add(grade);

            DisplayFromList();
        }

        public void arrayexamples()
        {
            runDisplay.Text = firstNames.Length + "\n";

            newFirstNames = new string[firstNames.Length * 3];

            for (int i = 0; i < firstNames.Length; i++)
            {
                newFirstNames[i] = firstNames[i];

            }
            firstNames = newFirstNames;

            runDisplay.Text += firstNames.Length + "";
        }
   
        public void DisplayStudents()
        {

            runDisplay.Text = "";
            for (int i = 0; i < firstNames.Length; i++)
            {
                //First Name Last Name - Grade
                runDisplay.Text += $"{firstNames[i]}{lastNames[i]}-{grades[i]}\n";
            }
        }
       

        private void btnInsertAt_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            int grade = int.Parse(txtGrade.Text);
            int index = int.Parse(txtInsertAt.Text);

            //To add to a list  = .ADD 
            firstNamesList.Insert(index, fName);
            lastNamesList.Insert(index, lName);
            gradeList.Insert(index, grade);

            DisplayFromList(); //CALLING METHOD 
        }

        private void btnRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtRemoveStudent.Text; //fName is in corporated in the txt.Remove

            bool wasRemoved = firstNamesList.Remove(fName); //Name.Remove, to remove data. 

            while (firstNamesList.Contains(fName)) 
                // This removes any matching input. It goes through the loop continuously until it 
                //achieve what it needs to. 
                
            {
                firstNamesList.Remove(fName);
            }

            //if (wasRemoved) // using IF to prompt a box to notify user if student was removed 
            //{
            //    MessageBox.Show(fName + "was removed from the class");
            //}
            //else // else , prompts when name was not originally on the list. 
            //{
            //    MessageBox.Show($"That name was not on the list.");
            //}
            
            foreach (string name in firstNamesList) //using for each to have access to all items in list
            {
                runDisplay.Text += name + "\n"; 
            }
        }
  

        private void btnRemoveAt_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(txtRemoveAt.Text);

            if (index < firstNamesList.Count)
            {
                firstNamesList.RemoveAt(index);
                lastNamesList.RemoveAt(index);
                gradeList.RemoveAt(index);
            }

            

            DisplayFromList();

        }
        public void exploringexample()
        {
            Random rand = new Random();
            for (int i = 0; i < 2000; i++)
            {
                firstNamesList.Add(i.ToString());
                lastNamesList.Add(i.ToString());
                gradeList.Add(rand.Next());

            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            HidePanels();
            panels[0].Visibility=Visibility.Visible;
        }

        private void btnAddStudentPanel_Click(object sender, RoutedEventArgs e)
        {
            HidePanels();
            panels[1].Visibility = Visibility.Visible;
        }

        private void btnRemovePanel_Click(object sender, RoutedEventArgs e)
        {
            HidePanels();
            panels[2].Visibility = Visibility.Visible;
        }

        private void btnRemoveAtPanel_Click(object sender, RoutedEventArgs e)
        {
            HidePanels();
            panels[3].Visibility = Visibility.Visible;
        }
    }
}
