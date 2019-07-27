using System;
using System.Windows;
using SocialGraph.DataAccess;
using System.Globalization;

namespace SocialGraph.DesktopClient
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SecondName { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Birthplace { get; set; }
        public string Residence { get; set; }
        public string Phone { get; set; }
        public string Hobbies { get; set; }
        public string FriendsIds { get; set; }

        public UserWindow(UserFull User)
        {
            FirstName = User.FirstName.TrimEnd(' ');
            MiddleName = User.MiddleName.TrimEnd(' ');
            SecondName = User.SecondName.TrimEnd(' ');
            Gender = User.Gender.TrimEnd(' ');
            Birthday = User.Birthday.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
            Birthplace = User.Birthplace.TrimEnd(' ');
            Residence = User.Residence.TrimEnd(' ');
            Phone = User.Phone.TrimEnd(' ');

            foreach (string Hobbie in User.Hobbies)
            {
                Hobbies += Hobbie.TrimEnd(' ') + ", ";
            }
            Hobbies = Hobbies.TrimEnd(',', ' ');

            foreach (Guid FriendId in User.Friends)
            {
                FriendsIds += FriendId.ToString() + '\n';
            }

            InitializeComponent();
        }
    }
}
