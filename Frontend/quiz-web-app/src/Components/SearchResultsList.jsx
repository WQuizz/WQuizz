import React, { useEffect, useState } from 'react';
import  "../Styles/searchresultslist.css";
import { useNavigate } from 'react-router-dom';

export const SearchResultsList = ({results, setInput, searchInput}) => {



      

    const navigate = useNavigate();

    const handleNavigation = () => {
      navigate('/playQuiz', { quizName: {setInput} });
    }

    return (
        <div className='results-list'>
            {
                results? results.map((result, id) => {
                    return result.quizName.toLowerCase() !== searchInput.toLowerCase() ?
                     <div 
                            key = {id} 
                            className='search-result' 
                            onClick ={() => {
                                setInput(result.quizName)
                                handleNavigation();
                            }}
                            >
                        {result.quizName}
                        </div>
                    : <></>
                })
                :
                <></>
            }
        </div>
    );
}