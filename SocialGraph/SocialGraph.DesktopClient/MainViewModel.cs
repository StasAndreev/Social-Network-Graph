using System;
using System.Collections;
using System.Collections.Generic;
using SocialGraph.DataAccess;
using System.Windows;
using QuickGraph;

namespace SocialGraph.DesktopClient
{
    public class MainViewModel
    {
        // Граф, отображающийся на главной форме
        public BidirectionalGraph<object, IEdge<object>> GraphToVisualize { get; set; }

        // Текст строки состояния (для вывода результатов http-запросов)
        public string StatusText { get; set; }

        private HttpHandler Http = null;

        public MainViewModel()
        {
            Http = new HttpHandler(this);

            if (Http.Connected)
                GraphToVisualize = BuildGraph();
        }
        
        public Command OnVertexClick
        {
            get { return new Command(ShowPersonInfo); }
        }

        private void ShowPersonInfo(object Id)
        {
            UserFull User = Http.GetUser((System.Guid)Id);
            UserWindow UserInfo = new UserWindow(User);
            UserInfo.Show();
        }

        // Построение графа
        private BidirectionalGraph<object, IEdge<object>> BuildGraph()
        {
            List<UserSummary> UserList = Http.GetUserList();
            Hashtable Vertice = new Hashtable();

            foreach (UserSummary u in UserList)
            {
                Vertice.Add(u.IdUser, new Vertex(u.IdUser));
            }

            var Graph = new BidirectionalGraph<object, IEdge<object>>();
            foreach (UserSummary u in UserList)
            {
                Graph.AddVertex(Vertice[u.IdUser]);
            }

            foreach (UserSummary u in UserList)
            {
                foreach (Guid IdFriend in u.Friends)
                {
                    Graph.AddEdge(new Edge<object>(Vertice[u.IdUser], Vertice[IdFriend]));
                }
            }
            return Graph;
        }
    }
}