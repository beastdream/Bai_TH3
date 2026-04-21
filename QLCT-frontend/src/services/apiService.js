import axios from 'axios';

// Tạo một instance của axios để dùng chung cấu hình
const api = axios.create({
    baseURL: "http://localhost:5000/api", // Cổng mặc định của .NET
    headers: {
        'Content-Type': 'application/json'
    },
    withCredentials: true // Quan trọng để gửi Cookie/Session nếu cần
});

export const transactionService = {
    // Lấy danh sách giao dịch
    getAll: (email) => api.get(`/Transactions?identifier=${email}`),
    
    // Thêm mới
    create: (data) => api.post('/Transactions', data),
    
    // Cập nhật
    update: (id, data) => api.put(`/Transactions/${id}`, data),
    
    // Xóa
    delete: (id) => api.delete(`/Transactions/${id}`)
};

export default api;