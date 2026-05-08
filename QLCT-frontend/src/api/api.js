import axiosClient from './axiosClient';

// Lấy danh sách giao dịch (GET):
export const getTransactions = () => {
  return axiosClient.get('/Transactions');
};

// Thêm giao dịch mới (POST):
export const addTransaction = (data) => {
  return axiosClient.post('/Transactions', data);
};

// Đăng ký tài khoản (POST):
export const register = (userData) => {
  return axiosClient.post('/public/register', userData);
};
