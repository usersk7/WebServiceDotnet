using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication2
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]



    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]

        public Publisher GetmyclassObj()
        {
            Publisher objpub = new Publisher(10,"shubham");
            return objpub;
        }

        [WebMethod]
        public DataSet GetDs()
        {
            DataSet ds = new DataSet();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Shubham;Integrated Security=True;Pooling=False";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "Emps");
            cn.Close();
            return ds;
        }

    

        [WebMethod]
        public void UpdateDs(DataSet ds)
        {


            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Shubham;Integrated Security=True;Pooling=False";
            cn.Open();

            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name=@Name, Basic =@Basic, DeptNo=@DeptNo where EmpNo = @EmpNo";

            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            da.UpdateCommand = cmdUpdate;

            //code for InsertCommand goes here

            SqlCommand cmdin = new SqlCommand();
            cmdin.Connection = cn;
            cmdin.CommandType = CommandType.Text;
            cmdin.CommandText = "insert into Employees values(@EmpNo,@Name, @Basic,@DeptNo)";
            cmdin.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            cmdin.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdin.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdin.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });

            da.InsertCommand = cmdin;

            //code for DeleteCommand goes here

            SqlCommand cmddel = new SqlCommand();

            cmddel.Connection = cn;
            cmddel.CommandType = CommandType.Text;
            cmddel.CommandText = "delete from Employees where EmpNo=@EmpNo";

            cmddel.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            da.DeleteCommand = cmddel;

            da.Update(ds, "Emps");

        }

    }

  

    public class Publisher
    {
        private int no;
        private String name;

        public int No { get => no; set => no = value; }
        public string Name { get => name; set => name = value; }


        public Publisher()
        {

        }
        public Publisher(int No, String Name)
        {
            this.No = No;
            this.Name = Name;

        }
    }

}
