import React, { useEffect, useState } from 'react';
import { getOrders } from '../services/api';

interface OrderItem {
    productId: number;
    productName: string;
    unitPrice: number;
    quantity: number;
}

interface Order {
    id: number;
    customer: string;
    orderDate: string;
    items: OrderItem[];
}

interface OrderListProps {
    onSelectOrder: (orderId: number) => void;
    reloadFlag: boolean;
}

const OrderList: React.FC<OrderListProps> = ({ onSelectOrder, reloadFlag }) => {
    const [orders, setOrders] = useState<Order[]>([]);

    const fetchOrders = () => {
        getOrders().then((response: { data: React.SetStateAction<Order[]>; }) => setOrders(response.data));
    };

    useEffect(() => {
        fetchOrders();
    }, [reloadFlag]);

    return (
        <div className="mb-4">
            <h1 className="text-2xl font-bold text-white">Order List</h1>
            <ul className="list-disc pl-5">
                {orders.map(order => (
                    <li key={order.id} onClick={() => onSelectOrder(order.id)} className="cursor-pointer hover:bg-gray-800 p-2 rounded">
                        <div>
                            <h5 className="text-xl text-gray-300">{order.customer}</h5>
                            <small className="text-gray-500">{new Date(order.orderDate).toLocaleString()}</small>
                            <ul className="list-disc pl-5 mt-2">
                                {order.items.map((item, index) => (
                                    <li key={index} className="text-gray-400">
                                        {item.productName} - ${item.unitPrice} x {item.quantity}
                                    </li>
                                ))}
                            </ul>
                        </div>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default OrderList;
