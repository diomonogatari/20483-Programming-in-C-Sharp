using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using School.Data;
using System.Globalization;

namespace School {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        // Connection to the School database
        private SchoolDBEntities schoolContext = null;

        // Field for tracking the currently selected teacher
        private Teacher teacher = null;

        // List for tracking the students assigned to the teacher's class
        private IList studentsInfo = null;

        #region Predefined code

        public MainWindow() {
            InitializeComponent();
        }

        // Connect to the database and display the list of teachers when the window appears
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            this.schoolContext = new SchoolDBEntities();
            teachersList.DataContext = this.schoolContext.Teachers;
        }

        // When the user selects a different teacher, fetch and display the students for that teacher
        private void teachersList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // Find the teacher that has been selected
            this.teacher = teachersList.SelectedItem as Teacher;
            this.schoolContext.LoadProperty<Teacher>(this.teacher, s => s.Students);

            // Find the students for this teacher
            this.studentsInfo = ((IListSource)teacher.Students).GetList();

            // Use databinding to display these students
            studentsList.DataContext = this.studentsInfo;
        }

        #endregion

        // When the user presses a key, determine whether to add a new student to a class, remove a student from a class, or modify the details of a student
        private void studentsList_KeyDown(object sender, KeyEventArgs e) {
            // TODO: Exercise 1: Task 1a: If the user pressed Enter, edit the details for the currently selected student

            switch (e.Key) {
                case Key.Enter:
                    //from the selected item, parse as a object from our school model
                    Student selectedStudent = ((ListView)sender).SelectedItem as Student;

                    //Exercise 1: Task 2a:
                    StudentForm s = new StudentForm();
                    s.firstName.Text = selectedStudent.FirstName;
                    s.lastName.Text = selectedStudent.LastName;
                    s.dateOfBirth.Text = selectedStudent.DateOfBirth.ToString("yyyy-MM-dd");

                    //Exercise 1: Task 2b:
                    s.Title = "Edit Student record";

                    //Exercise 1: Task 3a:
                    //if the form that is open returns true from the Ok button then a change was made
                    if (s.ShowDialog().Value) {

                        //Exercise 1: Task 3b:
                        //On closing with success save the data
                        selectedStudent.FirstName = s.firstName.Text;
                        selectedStudent.LastName = s.lastName.Text;
                        selectedStudent.DateOfBirth = DateTime.ParseExact(s.dateOfBirth.Text, "yyyy-MM-dd",CultureInfo.InvariantCulture);

                        //Exercise 1: Task 3c:
                        //because a change was made, the save button is now enabled
                        saveChanges.IsEnabled = true;
                    }
                    break;
            }
        }

        #region Predefined code

        private void studentsList_MouseDoubleClick(object sender, MouseButtonEventArgs e) {

        }

        // Save changes back to the database and make them permanent
        private void saveChanges_Click(object sender, RoutedEventArgs e) {
            schoolContext.SaveChanges();
            saveChanges.IsEnabled = false;
        }

        #endregion
    }

    [ValueConversion(typeof(string), typeof(Decimal))]
    class AgeConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture) {
            return "";
        }

        #region Predefined code

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
