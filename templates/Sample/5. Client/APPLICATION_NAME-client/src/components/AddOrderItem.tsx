import React, { useState } from 'react';
import { addOrderItem } from '../services/api';

interface AddOrderItemProps {
    orderId: number;
    onItemAdded: () => void;
}

const AddOrderItem: React.FC<AddOrderItemProps> = ({ orderId, onItemAdded }) => {
    const [productId, setProductId] = useState('');
    const [productName, setProductName] = useState('');
    const [unitPrice, setUnitPrice] = useState('');
    const [quantity, setQuantity] = useState('');

    const handleAddItem = async () => {
        await addOrderItem(orderId, parseInt(productId), productName, parseFloat(unitPrice), parseInt(quantity));
        onItemAdded(); // Notify parent to refresh the order list
        setProductId('');
        setProductName('');
        setUnitPrice('');
        setQuantity('');
    };

    return (
        <div>
            <h2 className="text-2xl font-bold text-white">Add an item to order {orderId}</h2>
            <div className="mb-4">
                <label className="block text-sm font-medium text-gray-400">Product ID</label>
                <input
                    type="number"
                    placeholder="Product ID"
                    value={productId}
                    onChange={(e) => setProductId(e.target.value)}
                    className="mt-1 block w-full bg-gray-700 border border-gray-600 text-white rounded-md shadow-sm"
                />
            </div>
            <div className="mb-4">
                <label className="block text-sm font-medium text-gray-400">Product Name</label>
                <input
                    type="text"
                    placeholder="Product Name"
                    value={productName}
                    onChange={(e) => setProductName(e.target.value)}
                    className="mt-1 block w-full bg-gray-700 border border-gray-600 text-white rounded-md shadow-sm"
                />
            </div>
            <div className="mb-4">
                <label className="block text-sm font-medium text-gray-400">Unit Price</label>
                <input
                    type="number"
                    placeholder="Unit Price"
                    value={unitPrice}
                    onChange={(e) => setUnitPrice(e.target.value)}
                    className="mt-1 block w-full bg-gray-700 border border-gray-600 text-white rounded-md shadow-sm"
                />
            </div>
            <div className="mb-4">
                <label className="block text-sm font-medium text-gray-400">Quantity</label>
                <input
                    type="number"
                    placeholder="Quantity"
                    value={quantity}
                    onChange={(e) => setQuantity(e.target.value)}
                    className="mt-1 block w-full bg-gray-700 border border-gray-600 text-white rounded-md shadow-sm"
                />
            </div>
            <button onClick={handleAddItem} className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600">Add Item</button>
        </div>
    );
}

export default AddOrderItem;
