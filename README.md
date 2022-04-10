# UnityUseMysql

打开SampleScene 点击Main Camera 填入DEtest数据，运行点击按钮即可测试连接数据库

# 数据库测试
1.确保数据库可以正常连接，通过数据库连接软件测试
![file](http://www.euph.cn/wp-content/uploads/2022/04/image-1649603930379.png)

# 安装Nuget包
安装Mysql 的Nuget 包，
https://github.com/GlitchEnzo/NuGetForUnity/releases
选择一个Release 的 unitypackage,安装进Unity

项目调整为Mono 使用.Net4.x
![file](http://www.euph.cn/wp-content/uploads/2022/04/image-1649604151301.png)

取消勾选 Assembly Version Validation
![file](http://www.euph.cn/wp-content/uploads/2022/04/image-1649604266516.png)

打开Unity Nuget manager，搜索Mysql安装
![file](http://www.euph.cn/wp-content/uploads/2022/04/image-1649604101863.png)

第一个即为最新版本的 mysql驱动 8.0.28

![file](http://www.euph.cn/wp-content/uploads/2022/04/image-1649604360407.png)
安装完成后，Assets下会多出一个Packages文件夹，里面即mysql需要用到的dll
# 测试
此时即可通过代码连接Mysql
参考代码：
```
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
}
```

输入mysql 对应数据，拖入一个Button,即可测试

![file](http://www.euph.cn/wp-content/uploads/2022/04/image-1649604662348.png)

![file](http://www.euph.cn/wp-content/uploads/2022/04/image-1649604866087.png)

