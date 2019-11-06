﻿using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using MBAF.EntityModel;

namespace MBAF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            DGVRefresh();

        }
        void DGVRefresh()
        {
      
            MainDataGridView.DataSource = DBObject.context.AudienceType.ToList();
            MainDataGridView.Columns["id"].Visible = false;
            MainDataGridView.Columns["Teacherid"].Visible = false;
            MainDataGridView.Columns["Corpid"].Visible = false;

        }

        private void ConnectDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGVRefresh();
        }

        private void DisconncetDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainDataGridView.DataSource = null;
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainDataGridView.DataSource != null)
            {
                DGVRefresh();

            }
        }

        void ShowAddAudience(AudienceType audience,Teacher teacher,Corps corps)
        {
            WinForms.AddAudience add = null;
            if (MainDataGridView.DataSource != null)
            {
                add = new WinForms.AddAudience(audience,teacher,corps);
                add.ShowDialog();
                add.Dispose();
                DGVRefresh();
            }
            else
                MessageBox.Show("Таблица не подключена! Пожалуйста подключите таблицу и попробуйте еще раз", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        void DeleteRow()
        {

            int? id = 0;

            if (MainDataGridView.DataSource != null)
                if (MainDataGridView.CurrentRow != null)
                {
                    id = Convert.ToInt32(MainDataGridView.CurrentRow.Cells[0].Value);
                    if (id != null)
                    {
                        EntityModel.AudienceType audience = DBObject.context.AudienceType.Where(c => c.Id == id).FirstOrDefault();
                        DBObject.context.Corps.Remove(audience.Corp);
                        DBObject.context.Teachers.Remove(audience.Teacher);
                        DBObject.context.AudienceType.Remove(audience);
                        DBObject.context.SaveChanges();
                        DGVRefresh();
                    }
                    else
                        MessageBox.Show("Таблица не подключена! Пожалуйста подключите таблицу и попробуйте еще раз", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Запись не выбрана! Пожалуйста выберете запись и попробуйте еще раз", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //void editrow(AudienceType audience = null)
        //{
        //    int Id = -1;
        //    if (MainDataGridView.DataSource != null)
        //    {
        //        if (MainDataGridView.CurrentRow != null)
        //        {
        //            Id = Convert.ToInt32(MainDataGridView.CurrentRow.Cells[0].Value);
        //            if (Id != null)
        //            {
        //                Model.EditRecords edit = new Model.EditRecords(audience);
        //                edit.ShowDialog();
        //                DGVRefresh();


        //            }
        //            else
        //                MessageBox.Show("Таблица не подключена! Пожалуйста подключите таблицу и попробуйте еще раз", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        else
        //            MessageBox.Show("Запись не выбрана! Пожалуйста выберете запись и попробуйте еще раз", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }

        //}

        private void AddAudienceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudienceType audience=new AudienceType();
            Teacher teacher = new Teacher();
            Corps corps = new Corps();
            ShowAddAudience(audience, teacher, corps);
        }

        private void УдалитьАудиториюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinForms.About about = new WinForms.About();
            about.ShowDialog();
            about.Dispose();
        }

        private void AdmintoolStripButton_Click(object sender, EventArgs e)
        {
            WinForms.Administrativ.AdminForm admin = new WinForms.Administrativ.AdminForm();
            WinForms.Administrativ.UnlockForm unlock = new WinForms.Administrativ.UnlockForm();
            unlock.ShowDialog();
            unlock.Dispose();
            admin.ShowDialog();
            admin.Dispose();


        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            WinForms.Administrativ.UnlockForm unlock = new WinForms.Administrativ.UnlockForm();
            unlock.ShowDialog();
            unlock.Dispose();
        }

        private void MainDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AudienceType audiencetype = (AudienceType)MainDataGridView.Rows[e.RowIndex].DataBoundItem;
            Teacher teacher = audiencetype.Teacher;
            Corps corps = audiencetype.Corp;
            ShowAddAudience(audiencetype,teacher, corps);
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
           MainDataGridView.DataSource = DBObject.context.AudienceType.Where(c => c.Teacher.Lname.Contains(searchTextBox.Text)|| c.Teacher.Fname.Contains(searchTextBox.Text) || c.Teacher.Mname.Contains(searchTextBox.Text) || c.TypeOf.Contains(searchTextBox.Text) || c.Corp.CorpNumber.ToString().Contains(searchTextBox.Text) || c.Capacity.ToString().Contains(searchTextBox.Text) ||c.Cabinet.Contains(searchTextBox.Text)).ToList();
        }
    }
}