import axios from 'axios';

const axiosClient = axios.create({
  baseURL: 'http://localhost:5117/api', // Cổng port bạn thấy trong Swagger
  headers: {
    'Content-Type': 'application/json',
  },
});

export default axiosClient;
