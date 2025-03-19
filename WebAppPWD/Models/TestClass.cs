namespace WebAppPWD.Models
{
    public interface ISort
    {
        void Sort(int[] arr);
    }
    public class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //using bubbl sort Alg
        }
    }

    public class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {
            //using bubbl sort Alg
        }
    }


    public class ChrisSort : ISort
    {
        
        public void Sort(int[] arr)
        {
            //throw new NotImplementedException();
        }
    }

    public class  MyList
    {
        int[] myArr;
        ISort Sort;//lossly couple   
        //dont create but ask 
        public MyList(ISort _sort)//injection
        {
            myArr = new int[10];
            // Sort = new BubbleSort();
            Sort = _sort;
        }
        public void SortList()//ISort sort)//BubbleSort bubbleSort;)
        {
            Sort.Sort(myArr);
        }
    }


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
            MyList list1 = new MyList(new BubbleSort());//injection consurtcion
            MyList list2 = new MyList(new SelectionSort());
            MyList list3 = new MyList(new ChrisSort());
            
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
