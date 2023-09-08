import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import {RockPaperScissor} from "../src/components/main/RockPaperScissor"

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <RockPaperScissor/>
    </React.StrictMode>
);
