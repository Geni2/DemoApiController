using System;
using System.Data;
using System.Data.SqlClient;
using DemoApiController.Models;

namespace DemoApiController.Models
{
    public class PorosiDBAccess
    {

        SqlConnection con = new SqlConnection("Server=MARIGLEN;Database=Porosite;Trusted_Connection=True;");
        public string AddPorosiRecord(Porosi porosi)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Porosite_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", porosi.Id);
                cmd.Parameters.AddWithValue("Name", porosi.Name);
                cmd.Parameters.AddWithValue("Address", porosi.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch(Exception ex)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();

                }
                return (ex.Message.ToString());
            }
        }
    }
}
