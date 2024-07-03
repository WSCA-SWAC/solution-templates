import React, { useState } from 'react';
import { createOrder } from '../services/api';

interface CreateOrderProps {
    onOrderCreated: () => void;
}

const CreateOrder: React.FC<CreateOrderProps> = ({ onOrderCreated }) => {
    const [customer, setCustomer] = useState('');

    const handleCreateOrder = async () => {
        await createOrder(customer);
        onOrderCreated(); // Notify parent to refresh the order list
        setCustomer('');
    };

    return (
        <div className="mb-4">
            <h2 className="text-2xl font-bold text-white">Create a new order</h2>
            <div className="mb-4">
                <label className="block text-sm font-medium text-gray-400">Customer</label>
                <input
                    type="text"
                    placeholder="Customer"
                    value={customer}
                    onChange={(e) => setCustomer(e.target.value)}
                    className="mt-1 block w-full bg-gray-700 border border-gray-600 text-white rounded-md shadow-sm"
                />
            </div>
            <button onClick={handleCreateOrder} className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600">Create Order</button>
        </div>
    );
}

export default CreateOrder;
