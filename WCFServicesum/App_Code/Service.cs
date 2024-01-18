using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	SqlConnection con = new SqlConnection(@"server=DESKTOP-3HUC9PM\SQLEXPRESS;database=NovDB;integrated security=true");
	public string Balance(string accno)
    {
		string s = "select balance from account2 where account_no = '" + accno + "'";
		SqlCommand cmd = new SqlCommand(s,con);
		con.Open();
		SqlDataReader dr = cmd.ExecuteReader();
		string bal = "";
		while(dr.Read())
        {
			bal = dr["balance"].ToString();
        }
		con.Close();
		return bal;
			
	}
	public int sum(int a,int b)
    {
		return (a + b);
    }
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
