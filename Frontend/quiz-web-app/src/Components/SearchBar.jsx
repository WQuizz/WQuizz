import React, {useState, Component} from 'react';
import {FaSearch} from "react-icons/fa";
import  "../Styles/searchbar.css"

export const SearchBar = () => {
    const [searchInput, setSearchInput] = useState("");
    
    

    return (
        <div className='search-bar-container'>
            <div className='input-wrapper'>
                <FaSearch id="search-icon"/>
                <input
                    type="text"
                    placeholder="Search here..."
                    value={searchInput}
                    
                    onChange={(e) => setSearchInput(e.target.value)}
                />
            
            </div>
        </div>
    );
}
