import React, {useState, Component} from 'react';
import {FaSearch} from "react-icons/fa";
import  "../Styles/searchbar.css"

export const SearchBar = () => {
    const [searchInput, setSearchInput] = useState("");
    const [searchResult, setSearchResult] = useState("");
    
    const fetchQuizzes = (value) => {
        fetch(`http://localhost:5015/api/Quiz/GetQuizzesContaining?searchTerm=${value}`)
            .then((response)=> response.json())
            .then((json) => {
                const results = json.map((quiz) => ({
                    quizName: quiz.quizName,
                    difficulty: quiz.difficulty,
                    thumbnailUrl: quiz.thumbnailUrl,
                    popularity: quiz.popularity,
                    rating: quiz.rating,
                }));
                console.log(results); // This will log an array of objects with the desired properties
                setSearchResult(results);
        })
        .catch((error) => {
            console.error("Error fetching data:", error);
            });
    }

    const handleChange = (value) => {
        setSearchInput(value);
        fetchQuizzes(value);
    }
    

    return (
        <div className='search-bar-container'>
            <div className='input-wrapper'>
                <FaSearch id="search-icon"/>
                <input
                    type="text"
                    placeholder="Search here..."
                    value={searchInput}
                    onChange={(e) => handleChange(e.target.value)}
                />
            
            </div>
        </div>
    );
}
