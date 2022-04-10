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

    #region ����MySql���ݿ�����

    /// <summary>
    /// �������ݿ�����.
    /// </summary>
    /// <returns>����MySqlConnection����</returns>
    private MySqlConnection GetMysqlConnection()
    {
        string M_str_sqlcon = string.Format("server={0};user id={1};password={2};database={3};port={4};", server, userid, password, database, port);
        MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
        return myCon;
    }

    #endregion ����MySql���ݿ�����

    private void Test()
    {
        MySqlConnection mysqlcon = this.GetMysqlConnection();
        mysqlcon.Open();
        try
        {
            bool isOK = mysqlcon.Ping();

            if (isOK)
            {
                Debug.LogError("���ݿ�����");
            }
            else
            {
                Debug.LogError("���ݿ����");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("���ݿ���� " + e.Message);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}