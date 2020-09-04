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
        List<NoteEntity> dataSource = new List<NoteEntity>();

        public UCTestCalendarNotes()
        {
            InitializeComponent();
            this.ucCalendarNotes1.CurrentTime = DateTime.Now;
            List<TestEntity> lstDB = LoadData();

            dataSource = GetShowData(lstDB);

            this.ucCalendarNotes1.DataSource = dataSource;

        }
        //这个相当于数据库数据
        List<TestEntity> DBSource = new List<TestEntity>();
        //从数据库读取数据
        private List<TestEntity> LoadData()
        {
            if (DBSource.Count <= 0)
            {

                DBSource.Add(new TestEntity() { ID = 1, Title = "一次循环测试1", Msg = "一次循环测试1内容", LoopType = 0, BeginDateTime = DateTime.Now.AddDays(-1), EndDateTime = DateTime.Now });
                DBSource.Add(new TestEntity() { ID = 2, Title = "一次循环测试2", Msg = "一次循环测试2内容", LoopType = 0, BeginDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddHours(2) });


                DBSource.Add(new TestEntity() { ID = 3, Title = "每天循环测试1", Msg = "一次循环测试1内容", LoopType = 1, BeginDateTime = DateTime.Now.AddDays(-5), EndDateTime = DateTime.Now, LoopBeginTime = DateTime.Parse("2000-02-02 " + "05:05:05"), LoopDuration = new TimeSpan(1, 1, 1) });
                DBSource.Add(new TestEntity() { ID = 4, Title = "每天循环测试2", Msg = "一次循环测试2内容", LoopType = 1, BeginDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddDays(5), LoopBeginTime = DateTime.Parse("2000-02-02 " + "10:05:05"), LoopDuration = new TimeSpan(1, 1, 1) });

                DBSource.Add(new TestEntity() { ID = 5, Title = "每周循环测试1", Msg = "一次循环测试1内容", LoopType = 2, BeginDateTime = DateTime.Now.AddDays(-5), EndDateTime = DateTime.Now, LoopBeginTime = DateTime.Parse("2000-02-02 " + "05:05:05"), LoopDuration = new TimeSpan(30, 1, 1), LoopDayIndex = 1 });
                DBSource.Add(new TestEntity() { ID = 6, Title = "每周循环测试2", Msg = "一次循环测试2内容", LoopType = 2, BeginDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddDays(5), LoopBeginTime = DateTime.Parse("2000-02-02 " + "10:05:05"), LoopDuration = new TimeSpan(10, 1, 1), LoopDayIndex = 2 });
                //每月、每年的和每周类似
            }
            return DBSource;
        }

        private List<NoteEntity> GetShowData(List<TestEntity> dbSource)
        {
            List<NoteEntity> lst = new List<NoteEntity>();
            foreach (var item in dbSource)
            {
                if (item.LoopType == 0)
                {
                    lst.Add(new NoteEntity() { Title = item.Title, Note = item.Msg, BeginTime = item.BeginDateTime, EndTime = item.EndDateTime, DataSource = item });
                }
                else if (item.LoopType == 1)
                {
                    DateTime thisDt = item.BeginDateTime;
                    while (thisDt <= item.EndDateTime)
                    {
                        DateTime noteBeginTime = DateTime.Parse(thisDt.ToString("yyyy-MM-dd") + " " + item.LoopBeginTime.ToString("HH:mm:ss"));
                        DateTime noteEndTime = noteBeginTime.Add(item.LoopDuration);
                        if (noteBeginTime >= item.BeginDateTime && noteEndTime < item.EndDateTime)//当天的计划 是否在整个计划范围时间内
                        {
                            lst.Add(new NoteEntity() { Title = item.Title, Note = item.Msg, BeginTime = noteBeginTime, EndTime = noteEndTime, DataSource = item });
                        }
                        thisDt = thisDt.AddDays(1);
                    }
                }
                else if (item.LoopType == 2)
                {
                    DateTime thisDt = item.BeginDateTime;
                    int thisWeek = (int)item.BeginDateTime.DayOfWeek;
                    if (thisWeek < item.LoopDayIndex)
                    {
                        thisDt = item.BeginDateTime.AddDays(item.LoopDayIndex - thisWeek);
                    }
                    else if (thisWeek > item.LoopDayIndex)
                    {
                        thisDt = item.BeginDateTime.AddDays(item.LoopDayIndex - thisWeek + 7);
                    }
                    thisDt = DateTime.Parse(thisDt.ToString("yyyy-MM-dd"));
                    while (thisDt <= item.EndDateTime)
                    {
                        DateTime noteBeginTime = DateTime.Parse(thisDt.ToString("yyyy-MM-dd") + " " + item.LoopBeginTime.ToString("HH:mm:ss"));
                        DateTime noteEndTime = noteBeginTime.Add(item.LoopDuration);
                        if (noteBeginTime >= item.BeginDateTime && noteEndTime < item.EndDateTime)//是否在整个计划范围时间内
                        {
                            lst.Add(new NoteEntity() { Title = item.Title, Note = item.Msg, BeginTime = noteBeginTime, EndTime = noteEndTime, DataSource = item });
                        }
                        thisDt = thisDt.AddDays(7);
                    }
                }
                else if (item.LoopType == 3)
                {
                    DateTime thisDt = item.BeginDateTime;
                    while (thisDt <= item.EndDateTime)
                    {
                        DateTime noteBeginTime = DateTime.Parse(thisDt.ToString("yyyy-MM-dd") + " " + item.LoopBeginTime.ToString("HH:mm:ss"));
                        DateTime noteEndTime = noteBeginTime.Add(item.LoopDuration);
                        if (noteBeginTime >= item.BeginDateTime && noteEndTime < item.EndDateTime)//是否在整个计划范围时间内
                        {
                            lst.Add(new NoteEntity() { Title = item.Title, Note = item.Msg, BeginTime = noteBeginTime, EndTime = noteEndTime, DataSource = item });
                        }
                        thisDt = thisDt.AddMonths(1);
                    }
                }
                //月，年类似周
            }

            return lst;
        }

        private bool ucCalendarNotes1_ClickNote(NoteEntity note)
        {
            TestEntity entity = (TestEntity)note.DataSource;

            //对entity进行修改、删除操作
            entity.Title += "修改1次；";
            //加载数据
            List<TestEntity> lstDB = LoadData();
            //获取控件绑定数据
            dataSource = GetShowData(lstDB);
            this.ucCalendarNotes1.DataSource = dataSource;
            MessageBox.Show("修改成功");
            return true;
        }
   

        private void ucCalendarNotes1_AddClick(DateTime beginTime)
        {
            //弹出一个新增窗体，新增数据
            //这一条模拟新增
            DBSource.Add(new TestEntity() { ID = 111, Title = "每周循环测试111", Msg = "一次循环测试1内容", LoopType = 2, BeginDateTime = beginTime, EndDateTime = DateTime.Now.AddDays(20), LoopBeginTime = DateTime.Parse("2000-02-02 " + "01:05:05"), LoopDuration = new TimeSpan(5, 1, 1), LoopDayIndex = (int)beginTime.DayOfWeek });
            //加载数据
            List<TestEntity> lstDB = LoadData();
            //获取控件绑定数据
            dataSource = GetShowData(lstDB);
            this.ucCalendarNotes1.DataSource = dataSource;
            MessageBox.Show("添加成功");
        }
    }

    public class TestEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Msg { get; set; }
        /// <summary>
        /// 0:一次 1：每天 2：每周 3：每月 4：每年
        /// </summary>
        public int LoopType { get; set; }
        /// <summary>
        /// 整个计划开始时间
        /// </summary>
        public DateTime BeginDateTime { get; set; }
        /// <summary>
        /// 整个计划结束时间
        /// </summary>
        public DateTime EndDateTime { get; set; }
        /// <summary>
        /// 每次循环开始时间,取时分秒部分
        /// </summary>
        public DateTime LoopBeginTime { get; set; }
        /// <summary>
        /// 每次循环时长,每天循环，次参数无效，
        /// </summary>
        public TimeSpan LoopDuration { get; set; }
        /// <summary>
        /// 每次循环的日期索引，
        /// 每天循环，次参数无效，
        /// 每周：星期几索引，周日=0...周六=6
        /// 每月：天索引
        /// 每年：天索引
        /// </summary>
        public int LoopDayIndex { get; set; }
    }
}
