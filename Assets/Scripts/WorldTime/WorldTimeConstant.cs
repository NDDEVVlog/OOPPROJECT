using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTime
{
    //biến tĩnh là biến có thể được chia sẻ và sử dụng bởi bất cứ đối tượng nào trong chương trình
    //hàm tĩnh là Giống với biến tĩnh, phương thức tĩnh cũng được khai báo với từ khóa static và
    //được sử dụng mà không cần phải khởi tạo đối tượng
    public static class WorldTimeConstant
    {
        public const int MinutesInDay = 1440;
    }
}