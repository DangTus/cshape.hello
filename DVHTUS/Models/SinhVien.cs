namespace DVHTUS.Models
{
    public class SinhVien
    {
        public int Id { get; set; }
        public string? HoTen { get; set; }
        public string? MaSV { get; set; }
        public string? Lop { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public ICollection<DangKyHocPhan>? DangKyHocPhans { get; set; }
    }
}
