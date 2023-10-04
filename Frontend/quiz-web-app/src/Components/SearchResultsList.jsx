import React from 'react';
import  "../Styles/searchresultslist.css";

export const SearchResultsList = ({results, setInput, searchInput}) => {

    return (
        <div className='results-list'>
            {
                results? results.map((result, id) => {
                    return result.quizName.toLowerCase() !== searchInput.toLowerCase() ?
                     <div 
                            key = {id} 
                            className='search-result' 
                            onClick ={() => setInput(result.quizName)}
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