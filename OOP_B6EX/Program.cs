using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_B6EX
{
    public class Course
    {
        private string id;
        private string title;
        private double weight;
        private double point;
        public Course(string id, string title, double weight, double point)
        {
            this.id = id;
            this.title = title;
            this.weight = weight;
            this.point = point;
        }

        public double Point { get => point; }

        public override string ToString()
        {
            return $"{title}<{Point}, {weight}>";
        }
        public static Course operator +(Course a, Course b)
        {
            return new Course("", "", 1,
                a.Point * a.weight + b.Point * b.weight);
        }
        public static Course operator /(Course a, Course b)
        {
            return new Course("", "", a.weight+ b.weight,
                (a.Point * a.weight + b.Point * b.weight)/ (a.weight+b.weight));
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Course toan = new Course("SE01", "Toan", 2, 8);
            Course ly = new Course("SE02", "Ly", 1, 7);
            Course hoa = new Course("SE03", "Hoa", 1, 9);
            double sum = (toan + ly + hoa).Point;
            double gpa = (toan/ly/hoa).Point;
            Console.WriteLine($"Sum: {sum}, GPA: {gpa}");
        }
    }
}
/*
Một lớp môn học gồm có các thuộc tính sau: mã môn, tên môn, trọng số, điểm số.
1/Xây dựng lớp môn học với các thuộc tính trên.
2/Quá tải ToString method dưới dạng: Tên môn<điểm, trọng số>
3/Xâu dựng operator + để cộng điểm của 2 môn theo trọng số.
4/Xây dựng operator / để tính điểm trung bình của 2 môn theo trọng số. 
5/Xây dựng hàm main với đầu vào là một danh sách các môn học mà một sinh viên nào đó đã học và test thử các methods. 
 */

/*LAP07(câu 1-5) - LAP08(6-7)#:
 Một lớp Point trong hệ tọa độ Descartes 2 chiều gốm các thuộc tính:x,y.
Một lớp Cluster chứa một list các Point
1/Xây dựng lớp Point.Khai báo getter, setter, constructor nếu cần.
2/Bổ sung vào Point: ToString dạng A(x,y), distance- tính khoảng cách giữa 2 điểm theo Euclidean.
3/Bổ sung vào lớp Cluster: ToString dạng {A(x,y), B(x,y)}
4/Bổ sung phương thức distance cho Cluster để tính khoảng cách giữa các cụm theo single linkage(theo khoảng cách nhỏ nhất giữa các cặp điểm của 2 cụm).
5/Bổ sung operator + để hợp 2 Cluster.
6/Cài đặt thuật toán hierarchical clustering để gom các cụm lại với nhau (với single linkage). Trong lớp Cluster, kết quả đầu ra là list của cluster.
        - public List<Cluster> HierarchicalClustering()
7/Triển khai kết quả trong hàm main.
 */