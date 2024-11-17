using Library.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602_Demo
{
    public partial class ChatForm : Form
    {
        private GameplayDataAccess dao = new GameplayDataAccess();
        public ChatForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dao.SendChat(GameManager.Instance.CurrentPlayer.Id, chatInput.Text);
        }
        private void UpdateChatList(object sender, EventArgs e)
        {
           
            chatList.Sort(chatList.Columns["TimeSent"], ListSortDirection.Ascending);

            chatList.DataSource = new SortableBindingList<Chat>(dao.GetChats(GameManager.Instance.CurrentPlayer.Id));
        }

    }
}
