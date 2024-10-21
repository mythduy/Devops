using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customer
{
    public class Program
    {
        static void Main(string[] args)


        {   Console.OutputEncoding = Encoding.UTF8;
            List<Customers> customers = new List<Customers>();
            Console.WriteLine("Nhap vao danh sach khach hang");
            Console.WriteLine("Nhap vao so luong khach hang: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Customers customer = null;
                bool isConfirmed = false;

                while (!isConfirmed)
                {
                    Console.WriteLine("Nhap thong tin khach hang thu " + (i + 1).ToString());

                    Console.WriteLine("Lưu ý: * Trường bắt buộc nhập thông tin\r\n" +
                        "Quý Khách vui lòng sử dụng tiếng Việt không dấu và không sử dụng các ký tự đặc biệt," +
                        " nhập đầy đủ tên hành khách và những thông tin khác xuất hiện trên (các) giấy tờ tùy thân do chính phủ cấp.\r\n" +
                        "Nếu Tên đầy đủ của Quý khách lớn hơn 41 ký tự, vui lòng viết tắt tên đệm.\r\n" +
                        "Ví dụ Tên đầy đủ của hành khách là: NGUYEN VUONG TRAN THI KIM NGUYET ANH DUONG MAI, " +
                        "Quý khách viết tắt như sau:\r\nĐệm và tên: V T T K N A DUONG MAI\r\nHọ: NGUYEN");

                    Console.WriteLine(" Tên đệm và tên (như trong CCCD/hộ chiếu)");
                    string firstName = Console.ReadLine();
                    Console.WriteLine(" Họ(như trong CCCD/hộ chiếu)");
                    string lastName = Console.ReadLine();
                    string name = lastName + " " + firstName;

                    Console.WriteLine("Nhập số CCCD/CMND ");
                    string IDCard = Console.ReadLine();
                    while (IDCard.Length != 8)
                    {
                        Console.WriteLine("Vui lòng nhập lại CCCD/CMND");
                        IDCard = Console.ReadLine();
                    }

                    Console.WriteLine("Nhập quốc tịch: ");
                    string citizenship = Console.ReadLine();

                    Console.WriteLine("Điện thoại ");
                    string phone = Console.ReadLine();

                    Console.WriteLine("Địa chỉ email bắt buộc ");
                    string email = Console.ReadLine();
                    while (!CheckEmail(email))
                    {
                        Console.WriteLine("Vui lòng nhập lại email");
                        email = Console.ReadLine();
                    }

                    Console.WriteLine("Ngày sinh yyyy/mm/dd");
                    Console.WriteLine("Định dạng là Năm/Tháng/Ngày");
                    DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập địa chỉ: ");
                    string diaChi = Console.ReadLine();

                    customer = new Customers(name, IDCard, citizenship, phone, email, dateOfBirth, diaChi);

                    Console.WriteLine("Thông tin khách hàng:");
                    Console.WriteLine(customer.ToString());
                    Console.WriteLine("Bạn có muốn xác nhận thông tin này? (y/n)");
                    string confirm = Console.ReadLine();
                    if (confirm.ToLower() == "y")
                    {
                        isConfirmed = true;
                    }
                    else
                    {
                        Console.WriteLine("Bạn muốn sửa thông tin nào?");
                        Console.WriteLine("1. Tên đệm và tên");
                        Console.WriteLine("2. Họ");
                        Console.WriteLine("3. Số CCCD/CMND");
                        Console.WriteLine("4. Quốc tịch");
                        Console.WriteLine("5. Điện thoại");
                        Console.WriteLine("6. Địa chỉ email");
                        Console.WriteLine("7. Ngày sinh");
                        Console.WriteLine("8. Địa chỉ");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine(" Tên đệm và tên (như trong CCCD/hộ chiếu)");
                                firstName = Console.ReadLine();
                                name = lastName + " " + firstName;
                                customer.Name = name;
                                break;
                            case 2:
                                Console.WriteLine(" Họ(như trong CCCD/hộ chiếu)");
                                lastName = Console.ReadLine();
                                name = lastName + " " + firstName;
                                customer.Name = name;
                                break;
                            case 3:
                                Console.WriteLine("Nhập số CCCD/CMND ");
                                IDCard = Console.ReadLine();
                                while (IDCard.Length != 8)
                                {
                                    Console.WriteLine("Vui lòng nhập lại CCCD/CMND");
                                    IDCard = Console.ReadLine();
                                }
                                customer.IDCard = IDCard;
                                break;
                            case 4:
                                Console.WriteLine("Nhập quốc tịch: ");
                                citizenship = Console.ReadLine();
                                customer.Citizenship = citizenship;
                                break;
                            case 5:
                                Console.WriteLine("Điện thoại ");
                                phone = Console.ReadLine();
                                customer.Phone = phone;
                                break;
                            case 6:
                                Console.WriteLine("Địa chỉ email bắt buộc ");
                                email = Console.ReadLine();
                                while (!CheckEmail(email))
                                {
                                    Console.WriteLine("Vui lòng nhập lại email");
                                    email = Console.ReadLine();
                                }
                                customer.Email = email;
                                break;
                            case 7:
                                Console.WriteLine("Ngày sinh yyyy/mm/dd");
                                Console.WriteLine("Định dạng là Năm/Tháng/Ngày");
                                dateOfBirth = DateTime.Parse(Console.ReadLine());
                                customer.DateOfBirth = dateOfBirth;
                                break;
                            case 8:
                                Console.WriteLine("Nhập địa chỉ: ");
                                diaChi = Console.ReadLine();
                                customer.Address = diaChi;
                                break;
                            default:
                                Console.WriteLine("Lựa chọn không hợp lệ.");
                                break;
                        }
                    }
                }

                customers.Add(customer);
            }

            Console.WriteLine("Danh sách khách hàng");
            Console.WriteLine("--------------------");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }

            Console.ReadKey();
        }
        public static bool CheckEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

    }   
}
