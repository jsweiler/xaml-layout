using FriendViewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FriendViewer.DesignTimeData
{
    public class DesignFriend : Friend
    {
        public DesignFriend()
        {
            FirstName = "Bob";
            LastName = "Jones";
            CellPhone = "1800-777-1459";
            Email = "bob@gmail.com";
            Homepage = "google.com";
            SetImageProperty();
        }
        void SetImageProperty()
        {

            var sri = Application.GetResourceStream(new Uri("FriendViewer;component/DesignTimeData/dog.jpg", UriKind.Relative));

            var length = sri.Stream.Length;
            var image = new byte[length];
            sri.Stream.Read(image, 0, (int)length);

            Image = image;
        }
    }
}
