using System;
using System.Collections.Generic;

namespace OOP_Lab01
{
    public class Sach
    {
        public string masach;
        public string tensach;
        public string tacgia;
        public string namsb;
        public uint soluong;
    }

    public class DocGia
    {
        public string madocgia;
        public string tendocgia;
        public string diachi;
        public string sdt;
    }

    public class PhieuMuon
    {
        public string maphieumuon;
        public string madocgia;
        public string masach;
        public DateTime ngaymuon;
        public DateTime ngaytra;
    }

    internal class Program
    {
        static List<Sach> sach = new List<Sach>();
        static List<DocGia> docgia = new List<DocGia>();
        static List<PhieuMuon> phieumuon = new List<PhieuMuon>();

        public static Sach ThemSach(string masach, string tensach, string tacgia, string namsb, uint soluong)
        {
            Sach book = new Sach();
            book.masach = masach;
            book.tensach = tensach;
            book.tacgia = tacgia;
            book.namsb = namsb; 
            book.soluong = soluong;
            return book;
        }

        public static DocGia ThemDocGia(string madocgia, string tendocgia, string diachi, string sdt)
        {
            DocGia dg = new DocGia();
            dg.madocgia = madocgia;
            dg.tendocgia = tendocgia;
            dg.diachi = diachi;
            dg.sdt = sdt;
            return dg;
        }

        public static void TimSach(string keyword)
        {
            
            foreach (Sach book in sach)
            {
                if (book.tensach.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    InThongKeSach("Tìm Sách", book);
                    return;
                }
            }

            Console.WriteLine("Không tìm thấy sách.");
        }

        public static void MuonSach(DocGia dg, string keyword)
        {
            foreach (Sach book in sach)
            {
                if (book.tensach.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 && book.soluong > 0)
                {
                    PhieuMuon pm = new PhieuMuon();
                    pm.maphieumuon = $"PM{phieumuon.Count + 1}";
                    pm.madocgia = dg.madocgia;
                    pm.masach = book.masach;
                    pm.ngaymuon = DateTime.Now;
                    pm.ngaytra = DateTime.Now.AddDays(14);
                    phieumuon.Add(pm);
                    book.soluong--;
                    InThongKePhieuMuon(dg, "Mượn Sách", pm);
                    InThongKeSach( null, book);
                    return;
                }
            }
            
            Console.WriteLine(" Không thể mượn sách.");
           
        }

        public static void TraSach(DocGia dg, string keyword)
        {
            foreach (PhieuMuon pm in phieumuon)
            {
                if (pm.madocgia == dg.madocgia)
                {
                    foreach (Sach book in sach)
                    {
                        if (book.tensach.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 && pm.masach == book.masach)
                        {
                            phieumuon.Remove(pm);
                            book.soluong++;
                            InThongKePhieuMuon(dg, "Trả Sách", pm);
                            InThongKeSach( null, book);
                            return;
                        }
                    }
                }
            }
            
            Console.WriteLine(" Không tìm thấy phiếu mượn.");
           
        }

        public static void InThongKeSach( string hanhdong, Sach book)
        {
            
            Console.WriteLine($"{hanhdong}");
            Console.WriteLine($"Thông tin sách:");
            Console.WriteLine($"  - Tên sách: {book.tensach}");
            Console.WriteLine($"  - Tác giả: {book.tacgia}");
            Console.WriteLine($"  - Năm XB: {book.namsb}");
            Console.WriteLine($"  - Số lượng còn: {book.soluong}");
            Console.WriteLine("====================\n");
        }
        public static void InThongKePhieuMuon(DocGia dg, string hanhdong, PhieuMuon pm)
        {
            Console.WriteLine("===== THỐNG KÊ =====");
            Console.WriteLine($"Mã độc giả: {dg.madocgia} - Tên độc giả: {dg.tendocgia} - Địa chỉ: {dg.diachi} - SĐT: {dg.sdt}");
            Console.WriteLine($"{hanhdong}");
            Console.WriteLine($"Thông tin phiếu mượn:");
            Console.WriteLine($"  - Mã phiếu mượn: {pm.maphieumuon}");
            Console.WriteLine($"  - Mã sách: {pm.masach}");
            Console.WriteLine($"  - Ngày mượn: {pm.ngaymuon:dd/mm/yyyy}");
            Console.WriteLine($"  - Ngày trả: {pm.ngaytra:dd/mm/yyyy}");
            Console.WriteLine("====================\n");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Sach s1 = ThemSach("S01", "Lập Trình C#", "Nguyễn Văn A", "2020", 10);
            sach.Add(s1);
            Sach s2 = ThemSach("S02", "Toán Cao Cấp", "Nguyễn Văn B", "2021", 5);
            sach.Add(s2);
            Sach s3 = ThemSach("S03", "Văn Học Việt Nam", "Nguyễn Văn C", "2019", 7);
            sach.Add(s3);
            Sach s4 = ThemSach("S01", "Lập Trình Java", "Nguyễn Văn A", "2020", 10);
            sach.Add(s4);

            DocGia d1 = ThemDocGia("D01", "Trần Văn H", "HCM", "0901234567");
            docgia.Add(d1);
            DocGia d2 = ThemDocGia("D02", "Nguyễn Thị M", "HN", "0987654321");
            docgia.Add(d2);

           
            TimSach("Lập Trình");
            MuonSach(docgia[1], "Toán cao cấp");
            TraSach(docgia[1], "Toán cao cấp");
           
        }
    }
}
