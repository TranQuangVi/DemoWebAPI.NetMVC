# DemoWebAPI
Có 3 cách để 2 team backend và frontend phối hợp với nhau:
- Một là team frontend clone project của team backend về và chạy project của team backend song song
- Hai là team backend sử dụng ngrok để chuyển đổi localhost sang một domain public mà team frontend có thể dễ dàng gọi vào.
- Cách thứ 3 là team backend xây dựng một API online đẩy lên Internet để team frontend ở bất cứ đâu có thể gọi trực tiếp vào đó.
# Bài demo tạo API đơn giản để hiểu hơn về Web API. 
Nhóm mình sẽ làm theo cách thứ nhất như trên để cho mọi người hiểu cơ bản về API.
Mình sẽ viết API :
- GetListBooks: lấy danh sách các sách, 
- GetBook: lấy 1 sách theo ID, 
- CreateNew: tạo mới sách, 
- UpdateBook: chỉnh sửa sách, 
- DeleteBook: xóa sách.
