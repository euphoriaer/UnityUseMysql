using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.UI;

public class DBTest : MonoBehaviour
{
    public Button DbButton;
    public string server = "";
    public string userid = "";
    public string password = "";
    public string database = "";
    public string port = "3306";
 
    // Start is called before the first frame update
    private void Start()
    {
        DbButton.onClick.AddListener(Test);
    }

    #region 建立MySql数据库连接

    /// <summary>
    /// 建立数据库连接.
    /// </summary>
    /// <returns>返回MySqlConnection对象</returns>
    private MySqlConnection GetMysqlConnection()
    {
        string M_str_sqlcon = string.Format("server={0};user id={1};password={2};database={3};port={4};", server, userid, password, database, port);
        MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
        return myCon;
    }

    #endregion 建立MySql数据库连接

    private void Test()
    {
        MySqlConnection mysqlcon = this.GetMysqlConnection();
        mysqlcon.Open();
        try
        {
            bool isOK = mysqlcon.Ping();

            if (isOK)
            {
                Debug.LogError("数据库正常");
            }
            else
            {
                Debug.LogError("数据库错误");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("数据库错误： " + e.Message);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}