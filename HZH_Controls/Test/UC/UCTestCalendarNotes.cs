using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;

namespace Test.UC
{
    public partial class UCTestCalendarNotes : UserControl
    {
        public UCTestCalendarNotes()
        {
            InitializeComponent();
            List<NoteEntity> dataSource = new List<NoteEntity>();
            dataSource.Add(new NoteEntity() { Key = "1", BeginTime = DateTime.Now, Title = "aaaa", Note = "agaweas" });
            dataSource.Add(new NoteEntity() { Key = "1", BeginTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Title = "bbbb", Note = "bbbbdfasdfg" });
            dataSource.Add(new NoteEntity() { Key = "1", BeginTime = DateTime.Now.AddHours(-3), EndTime = DateTime.Now.AddHours(-1), Title = "ccc", Note = "bbbbdfasdfg" });
            dataSource.Add(new NoteEntity() { Key = "1", BeginTime = DateTime.Now.AddDays(-1), EndTime = DateTime.Now, Title = "ddd", Note = "bbbbdfasdfg" });
            this.ucCalendarNotes1.DataSource = dataSource;

            this.ucCalendarNotes_Week1.DataSource = dataSource;
            this.ucCalendarNotes_Week1.CurrentTime = DateTime.Now;
        }

        private bool ucCalendarNotes1_ClickNote(NoteEntity note)
        {
            MessageBox.Show("点击了备忘【"+note.Title+"】，你可以在这里对备忘编辑，修改，如果要修改，请返回true，否则返回false，如果要删除，删除后重新赋值ucCalendarNotes控件DataSource属性");
            return default(bool);
        }
    }
}
