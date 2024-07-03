import axios from 'axios';

const api = axios.create(
    {
        baseURL: 'http://localhost:5096/api',
        withCredentials: false,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS',
        }
    });

export const getOrders = () => api.get('/order');
export const getOrderById = (id: number) => api.get(`/order/${id}`);
export const createOrder = (customer: string) => api.post('/order', { customer });
export const addOrderItem = (orderId: number, productId: number, productName: string, unitPrice: number, quantity: number) =>
    api.post(`/order/${orderId}/items`, { productId, productName, unitPrice, quantity });

