import React, {useState, useEffect, Component} from 'react';
import {FaSearch} from "react-icons/fa";
import  "../Styles/searchbar.css";
import {SearchResultsList} from "./SearchResultsList";

export const SearchBar = () => {
    const [searchInput, setSearchInput] = useState("");
    const [searchResult, setSearchResult] = useState("");
    
    useEffect(()=>{
        searchInput? 
        fetch(`http://localhost:9000/api/Quiz/GetQuizzesContaining?searchTerm=${searchInput}`)
            .then((response)=> response.json())
            .then((json) => {
                const results = json.map((quiz) => ({
                    quizName: quiz.quizName,
                    difficulty: quiz.difficulty,
                    thumbnailUrl: quiz.thumbnailUrl,
                    popularity: quiz.popularity,
                    rating: quiz.rating,
                }));
                setSearchResult(results);
        })
        .catch((error) => {
            console.error("Error fetching data:", error);
            })
            : setSearchResult("");
    }, [searchInput])


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
            <SearchResultsList results = {searchResult} setInput = {setSearchInput} searchInput = {searchInput}/>
        </div>
    );
}
