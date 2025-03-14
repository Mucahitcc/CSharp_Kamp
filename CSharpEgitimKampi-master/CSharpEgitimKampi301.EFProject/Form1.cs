﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void BtnList_Click(object sender, EventArgs e)
        {
            
            var values =db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Guide guide=new Guide();

            guide.GuideName=TxtName.Text;
            guide.GuideSurname=TxtSurname.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehbere Başarıyla Eklendi");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id =int.Parse( TxtId.Text);

            var remoValue=db.Guide.Find(id);
            db.Guide.Remove(remoValue);
            db.SaveChanges() ;
            MessageBox.Show("Rehber başarıyla silindi");

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse( TxtId.Text);
            var updateValue=db.Guide.Find(id);
            updateValue.GuideName =TxtName.Text;
            updateValue.GuideSurname =TxtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellendi");
        }

        private void BtnGetId_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);

            var values=db.Guide.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
