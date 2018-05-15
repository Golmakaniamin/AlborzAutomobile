using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Resources;

namespace CrystalReportWpf_AlborzAutomobile
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SqlConnection objConnection = new SqlConnection();
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string selkar;
        public string id_Contract;
        public string rec_sel_for;
        public string prompt;

        public string date1;
        public string date2;

        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (selkar == "Crystal_Leasing_01_Haghol_Vekaleh")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ReportDocument Crystal_Rusty_01_hagholamal_kari = new ReportDocument();
                Crystal_Rusty_01_hagholamal_kari.Load(@"Print\Crystal_Leasing_01_Haghol_Vekaleh.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_01_hagholamal_kari.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_01_hagholamal_kari.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_01_hagholamal_kari;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Leasing_02_Havalehe_Tahvil")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ReportDocument Crystal_Leasing_02_Havalehe_Tahvil = new ReportDocument();
                Crystal_Leasing_02_Havalehe_Tahvil.Load(@"Print\Crystal_Leasing_02_Havalehe_Tahvil.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Leasing_02_Havalehe_Tahvil.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Leasing_02_Havalehe_Tahvil.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Leasing_02_Havalehe_Tahvil;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_01_hagholamal_kari")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@udate";
                paramField3.ReportName = "Amin_pelak1";
                paramDiscreteValue3.Value = u_set.u_date();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@udate";
                paramField4.ReportName = "Amin_pelak2";
                paramDiscreteValue4.Value = u_set.u_date();
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                paramField5.Name = "@udate";
                paramField5.ReportName = "Amin_pelak3";
                paramDiscreteValue5.Value = u_set.u_date();
                paramField5.CurrentValues.Add(paramDiscreteValue5);
                paramFields.Add(paramField5);

                ParameterField paramField6 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue6 = new ParameterDiscreteValue();
                paramField6.Name = "@uuser";
                paramDiscreteValue6.Value = u_set.u_user();
                paramField6.CurrentValues.Add(paramDiscreteValue6);
                paramFields.Add(paramField6);

                ParameterField paramField7 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue7 = new ParameterDiscreteValue();
                paramField7.Name = "@uuser";
                paramField7.ReportName = "Amin_pelak1";
                paramDiscreteValue7.Value = u_set.u_user();
                paramField7.CurrentValues.Add(paramDiscreteValue7);
                paramFields.Add(paramField7);

                ParameterField paramField8 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue8 = new ParameterDiscreteValue();
                paramField8.Name = "@uuser";
                paramField8.ReportName = "Amin_pelak2";
                paramDiscreteValue8.Value = u_set.u_user();
                paramField8.CurrentValues.Add(paramDiscreteValue8);
                paramFields.Add(paramField8);

                ParameterField paramField9 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue9 = new ParameterDiscreteValue();
                paramField9.Name = "@uuser";
                paramField9.ReportName = "Amin_pelak3";
                paramDiscreteValue9.Value = u_set.u_user();
                paramField9.CurrentValues.Add(paramDiscreteValue9);
                paramFields.Add(paramField9);

                ReportDocument Crystal_Rusty_01_hagholamal_kari = new ReportDocument();
                Crystal_Rusty_01_hagholamal_kari.Load(@"Print\Crystal_Rusty_01_hagholamal_kari.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_01_hagholamal_kari.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_01_hagholamal_kari.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_01_hagholamal_kari;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_01_Eghrar1")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@udate";
                paramField3.ReportName = "Amin_pelak1";
                paramDiscreteValue3.Value = u_set.u_date();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@udate";
                paramField4.ReportName = "Amin_pelak2";
                paramDiscreteValue4.Value = u_set.u_date();
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                paramField5.Name = "@udate";
                paramField5.ReportName = "Amin_pelak3";
                paramDiscreteValue5.Value = u_set.u_date();
                paramField5.CurrentValues.Add(paramDiscreteValue5);
                paramFields.Add(paramField5);

                ParameterField paramField6 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue6 = new ParameterDiscreteValue();
                paramField6.Name = "@uuser";
                paramDiscreteValue6.Value = u_set.u_user();
                paramField6.CurrentValues.Add(paramDiscreteValue6);
                paramFields.Add(paramField6);

                ParameterField paramField7 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue7 = new ParameterDiscreteValue();
                paramField7.Name = "@uuser";
                paramField7.ReportName = "Amin_pelak1";
                paramDiscreteValue7.Value = u_set.u_user();
                paramField7.CurrentValues.Add(paramDiscreteValue7);
                paramFields.Add(paramField7);

                ParameterField paramField8 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue8 = new ParameterDiscreteValue();
                paramField8.Name = "@uuser";
                paramField8.ReportName = "Amin_pelak2";
                paramDiscreteValue8.Value = u_set.u_user();
                paramField8.CurrentValues.Add(paramDiscreteValue8);
                paramFields.Add(paramField8);

                ParameterField paramField9 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue9 = new ParameterDiscreteValue();
                paramField9.Name = "@uuser";
                paramField9.ReportName = "Amin_pelak3";
                paramDiscreteValue9.Value = u_set.u_user();
                paramField9.CurrentValues.Add(paramDiscreteValue9);
                paramFields.Add(paramField9);

                ReportDocument Crystal_Rusty_01_Eghrar1 = new ReportDocument();
                Crystal_Rusty_01_Eghrar1.Load(@"Print\Crystal_Rusty_01_Eghrar1.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_01_Eghrar1.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_01_Eghrar1.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_01_Eghrar1;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_01_Eghrar2")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@udate";
                paramField3.ReportName = "Amin_pelak1";
                paramDiscreteValue3.Value = u_set.u_date();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@udate";
                paramField4.ReportName = "Amin_pelak2";
                paramDiscreteValue4.Value = u_set.u_date();
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                paramField5.Name = "@udate";
                paramField5.ReportName = "Amin_pelak3";
                paramDiscreteValue5.Value = u_set.u_date();
                paramField5.CurrentValues.Add(paramDiscreteValue5);
                paramFields.Add(paramField5);

                ParameterField paramField6 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue6 = new ParameterDiscreteValue();
                paramField6.Name = "@uuser";
                paramDiscreteValue6.Value = u_set.u_user();
                paramField6.CurrentValues.Add(paramDiscreteValue6);
                paramFields.Add(paramField6);

                ParameterField paramField7 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue7 = new ParameterDiscreteValue();
                paramField7.Name = "@uuser";
                paramField7.ReportName = "Amin_pelak1";
                paramDiscreteValue7.Value = u_set.u_user();
                paramField7.CurrentValues.Add(paramDiscreteValue7);
                paramFields.Add(paramField7);

                ParameterField paramField8 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue8 = new ParameterDiscreteValue();
                paramField8.Name = "@uuser";
                paramField8.ReportName = "Amin_pelak2";
                paramDiscreteValue8.Value = u_set.u_user();
                paramField8.CurrentValues.Add(paramDiscreteValue8);
                paramFields.Add(paramField8);

                ParameterField paramField9 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue9 = new ParameterDiscreteValue();
                paramField9.Name = "@uuser";
                paramField9.ReportName = "Amin_pelak3";
                paramDiscreteValue9.Value = u_set.u_user();
                paramField9.CurrentValues.Add(paramDiscreteValue9);
                paramFields.Add(paramField9);

                ReportDocument Crystal_Rusty_01_Eghrar2 = new ReportDocument();
                Crystal_Rusty_01_Eghrar2.Load(@"Print\Crystal_Rusty_01_Eghrar2.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_01_Eghrar2.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_01_Eghrar2.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_01_Eghrar2;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_12_Havalehe_Tahvil")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@uuser";
                paramDiscreteValue3.Value = u_set.u_user();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ReportDocument Crystal_Rusty_12_Havalehe_Tahvil = new ReportDocument();
                Crystal_Rusty_12_Havalehe_Tahvil.Load(@"Print\Crystal_Rusty_12_Havalehe_Tahvil.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_12_Havalehe_Tahvil.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_12_Havalehe_Tahvil.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_12_Havalehe_Tahvil;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_01_Lablel")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ReportDocument Crystal_Rusty_01_Lablel = new ReportDocument();
                Crystal_Rusty_01_Lablel.Load(@"Print\Crystal_Rusty_01_Lablel.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_01_Lablel.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_01_Lablel.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_01_Lablel;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_All_Ravandkar")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@udate";
                paramField3.ReportName = "Amin_pelak1";
                paramDiscreteValue3.Value = u_set.u_date();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@udate";
                paramField4.ReportName = "Amin_pelak2";
                paramDiscreteValue4.Value = u_set.u_date();
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                paramField5.Name = "@udate";
                paramField5.ReportName = "Amin_pelak3";
                paramDiscreteValue5.Value = u_set.u_date();
                paramField5.CurrentValues.Add(paramDiscreteValue5);
                paramFields.Add(paramField5);

                ReportDocument Crystal_Rusty_All_Ravandkar = new ReportDocument();
                Crystal_Rusty_All_Ravandkar.Load(@"Print\Crystal_Rusty_All_Ravandkar.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_All_Ravandkar.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_All_Ravandkar.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_All_Ravandkar;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_All_Ravandkar_Main")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@uuser";
                paramDiscreteValue1.Value = u_set.u_user();
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@utime";
                paramDiscreteValue3.Value = u_set.u_time();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@uname";
                paramDiscreteValue4.Value = "گزارش روند کار فرسوده (" + prompt + ")";
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ReportDocument Crystal_Rusty_All_Ravandkar_Main = new ReportDocument();
                Crystal_Rusty_All_Ravandkar_Main.Load(@"Print\Crystal_Rusty_All_Ravandkar_Main.rpt");
                Crystal_Rusty_All_Ravandkar_Main.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_All_Ravandkar_Main.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_All_Ravandkar_Main.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_All_Ravandkar_Main;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_All_Ravandkar_Main_naghd")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@uuser";
                paramDiscreteValue1.Value = u_set.u_user();
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@utime";
                paramDiscreteValue3.Value = u_set.u_time();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@uname";
                paramDiscreteValue4.Value = "گزارش روند کار فرسوده (" + prompt + ")";
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ReportDocument Crystal_Rusty_All_Ravandkar_Main_naghd = new ReportDocument();
                Crystal_Rusty_All_Ravandkar_Main_naghd.Load(@"Print\Crystal_Rusty_All_Ravandkar_Main_naghd.rpt");
                Crystal_Rusty_All_Ravandkar_Main_naghd.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_All_Ravandkar_Main_naghd.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_All_Ravandkar_Main_naghd.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_All_Ravandkar_Main_naghd;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_Customers")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@uuser";
                paramDiscreteValue1.Value = u_set.u_user();
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@utime";
                paramDiscreteValue3.Value = u_set.u_time();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@uname";
                paramDiscreteValue4.Value = "گزارش روند کار فرسوده (" + prompt + ")";
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ReportDocument Crystal_Rusty_Customers = new ReportDocument();
                Crystal_Rusty_Customers.Load(@"Print\Crystal_Rusty_Customers.rpt");
                Crystal_Rusty_Customers.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_Customers.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_Customers.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_Customers;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Rusty_PPrint_02_vekalatnameh")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@uuser";
                paramDiscreteValue1.Value = u_set.u_user();
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@utime";
                paramDiscreteValue3.Value = u_set.u_time();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@udate1";
                paramDiscreteValue4.Value = date1;
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                paramField5.Name = "@udate2";
                paramDiscreteValue5.Value = date2;
                paramField5.CurrentValues.Add(paramDiscreteValue5);
                paramFields.Add(paramField5);

                ReportDocument Rusty_PPrint_02_vekalatnameh = new ReportDocument();
                Rusty_PPrint_02_vekalatnameh.Load(@"Print\Rusty_PPrint_02_vekalatnameh.rpt");
                Rusty_PPrint_02_vekalatnameh.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Rusty_PPrint_02_vekalatnameh.Database.Tables.Count - 1; intCounter++)
                {
                    Rusty_PPrint_02_vekalatnameh.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Rusty_PPrint_02_vekalatnameh;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Rusty_PPrint_03_sabtvarizi")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@uuser";
                paramDiscreteValue1.Value = u_set.u_user();
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@utime";
                paramDiscreteValue3.Value = u_set.u_time();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@udate1";
                paramDiscreteValue4.Value = date1;
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                paramField5.Name = "@udate2";
                paramDiscreteValue5.Value = date2;
                paramField5.CurrentValues.Add(paramDiscreteValue5);
                paramFields.Add(paramField5);

                ReportDocument Rusty_PPrint_03_sabtvarizi = new ReportDocument();
                Rusty_PPrint_03_sabtvarizi.Load(@"Print\Rusty_PPrint_03_sabtvarizi.rpt");
                Rusty_PPrint_03_sabtvarizi.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Rusty_PPrint_03_sabtvarizi.Database.Tables.Count - 1; intCounter++)
                {
                    Rusty_PPrint_03_sabtvarizi.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Rusty_PPrint_03_sabtvarizi;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Rusty_PPrint_04_hesab")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@uuser";
                paramDiscreteValue1.Value = u_set.u_user();
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@utime";
                paramDiscreteValue3.Value = u_set.u_time();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@udate1";
                paramDiscreteValue4.Value = date1;
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                paramField5.Name = "@udate2";
                paramDiscreteValue5.Value = date2;
                paramField5.CurrentValues.Add(paramDiscreteValue5);
                paramFields.Add(paramField5);

                ReportDocument Rusty_PPrint_04_hesab = new ReportDocument();
                Rusty_PPrint_04_hesab.Load(@"Print\Rusty_PPrint_04_hesab.rpt");
                Rusty_PPrint_04_hesab.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Rusty_PPrint_04_hesab.Database.Tables.Count - 1; intCounter++)
                {
                    Rusty_PPrint_04_hesab.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Rusty_PPrint_04_hesab;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Rusty_PPrint_05_sabtdarsetad13")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@uuser";
                paramDiscreteValue1.Value = u_set.u_user();
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@utime";
                paramDiscreteValue3.Value = u_set.u_time();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@udate1";
                paramDiscreteValue4.Value = date1;
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                paramField5.Name = "@udate2";
                paramDiscreteValue5.Value = date2;
                paramField5.CurrentValues.Add(paramDiscreteValue5);
                paramFields.Add(paramField5);

                ReportDocument Rusty_PPrint_05_sabtdarsetad13 = new ReportDocument();
                Rusty_PPrint_05_sabtdarsetad13.Load(@"Print\Rusty_PPrint_05_sabtdarsetad13.rpt");
                Rusty_PPrint_05_sabtdarsetad13.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Rusty_PPrint_05_sabtdarsetad13.Database.Tables.Count - 1; intCounter++)
                {
                    Rusty_PPrint_05_sabtdarsetad13.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Rusty_PPrint_05_sabtdarsetad13;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Rusty_PPrint_06_farakhan")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@uuser";
                paramDiscreteValue1.Value = u_set.u_user();
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@utime";
                paramDiscreteValue3.Value = u_set.u_time();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@udate1";
                paramDiscreteValue4.Value = date1;
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                paramField5.Name = "@udate2";
                paramDiscreteValue5.Value = date2;
                paramField5.CurrentValues.Add(paramDiscreteValue5);
                paramFields.Add(paramField5);

                ReportDocument Rusty_PPrint_06_farakhan = new ReportDocument();
                Rusty_PPrint_06_farakhan.Load(@"Print\Rusty_PPrint_06_farakhan.rpt");
                Rusty_PPrint_06_farakhan.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Rusty_PPrint_06_farakhan.Database.Tables.Count - 1; intCounter++)
                {
                    Rusty_PPrint_06_farakhan.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Rusty_PPrint_06_farakhan;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_11_resid")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@uuser";
                paramDiscreteValue3.Value = u_set.u_user();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ReportDocument Crystal_Rusty_11_resid = new ReportDocument();
                Crystal_Rusty_11_resid.Load(@"Print\Crystal_Rusty_11_resid.rpt");
                Crystal_Rusty_11_resid.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_11_resid.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_11_resid.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_11_resid;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_12_resid")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@uuser";
                paramDiscreteValue3.Value = u_set.u_user();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ReportDocument Crystal_Rusty_12_resid = new ReportDocument();
                Crystal_Rusty_12_resid.Load(@"Print\Crystal_Rusty_12_resid.rpt");
                Crystal_Rusty_12_resid.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_12_resid.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_12_resid.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_12_resid;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Financial_Cost")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@ttmpid";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ReportDocument Crystal_Financial_Cost = new ReportDocument();
                Crystal_Financial_Cost.Load(@"Print\Crystal_Financial_Cost.rpt");
                Crystal_Financial_Cost.RecordSelectionFormula = rec_sel_for;

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Financial_Cost.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Financial_Cost.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Financial_Cost;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Rusty_User")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ReportDocument Crystal_Rusty_User = new ReportDocument();
                Crystal_Rusty_User.Load(@"Print\Crystal_Rusty_User.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Rusty_User.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Rusty_User.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Rusty_User;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Sell_Buy_01_Gholnameh")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@udate";
                paramDiscreteValue2.Value = u_set.u_date();
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@uuser";
                paramDiscreteValue3.Value = u_set.u_date();
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                ReportDocument Crystal_Sell_Buy_01_Gholnameh = new ReportDocument();
                Crystal_Sell_Buy_01_Gholnameh.Load(@"Print\Crystal_Sell_Buy_01_Gholnameh.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Sell_Buy_01_Gholnameh.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Sell_Buy_01_Gholnameh.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Sell_Buy_01_Gholnameh;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

            if (selkar == "Crystal_Cash_and_installment_sales_01_Haghol_Vekaleh")
            {
                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@id_gharardad";
                paramDiscreteValue1.Value = id_Contract;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ReportDocument Crystal_Cash_and_installment_sales_01_Haghol_Vekaleh = new ReportDocument();
                Crystal_Cash_and_installment_sales_01_Haghol_Vekaleh.Load(@"Print\Crystal_Cash_and_installment_sales_01_Haghol_Vekaleh.rpt");

                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = DB_Base.Constr3;
                ConInfo.ConnectionInfo.Password = DB_Base.Constr4;
                ConInfo.ConnectionInfo.ServerName = DB_Base.Constr0;
                ConInfo.ConnectionInfo.DatabaseName = DB_Base.Constr1;
                for (int intCounter = 0; intCounter <= Crystal_Cash_and_installment_sales_01_Haghol_Vekaleh.Database.Tables.Count - 1; intCounter++)
                {
                    Crystal_Cash_and_installment_sales_01_Haghol_Vekaleh.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }
                crystalReportsViewer1.ViewerCore.ReportSource = Crystal_Cash_and_installment_sales_01_Haghol_Vekaleh;
                crystalReportsViewer1.ViewerCore.ParameterFieldInfo = paramFields;
            }

        }
    }
}
