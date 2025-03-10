namespace WebAppPWD.Models
{
    public class TestClass
    {
        object obj;

        public object Obj {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        
        }

        public dynamic ObjDynamic
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        public  int  MEthod1()
        {
            
            //object x = 1;
            //object obj = new Student();
            //string name = ((Student)obj).Name;


            dynamic x = 1;
            dynamic obj = new Student();
            dynamic z = x + obj;//compilation ,trow exception
            string name = obj.Name;
            return MEthod2();
        }
        public int MEthod2()
        {
            return 1;
        }
    }
}
