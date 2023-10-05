import React, {useState, useEffect, useRef, Component, useCallback} from 'react';
import  "../Styles/quizslider.css";

export const QuizSlider = () =>{

    const [currentIndex, setCurrentIndex] = useState(0);
    const [quizArray, setQuizArray] = useState([]);
    const [idToFetch, setIdToFetch] = useState([1,2,3,4]);

    //autoslide usestates
    const timeRef = useRef(null);
    
    const sliderContainerRef = useRef(null); // Create a ref for slidercontainer
    const [sliderContainerWidth, setSliderContainerWidth] = useState(0);

    useEffect(()=>{
        idToFetch.forEach(id => {
            fetch(`http://localhost:9000/api/Quiz/GetQuizById?id=${id}`)
                .then((response)=> response.json())
                .then((quiz) => {
                    const result = {
                        quizName: quiz.quizName,
                        difficulty: quiz.difficulty,
                        thumbnailUrl: quiz.thumbnailUrl,
                        popularity: quiz.popularity,
                        rating: quiz.rating
                    }
                    setQuizArray(prevArray => [...prevArray, result]);
                    
            })
            .catch((error) => {
                console.error("Error fetching data:", error);
            })
        });
    },[idToFetch])

    //Autoslide useeffect
    useEffect(()=>{
        if (timeRef.current) {
            clearTimeout(timeRef.current)
        }
        timeRef.current = setTimeout(()=>{
            goToNext();
        },4000)

        return () => clearTimeout(timeRef.current);
    }, [currentIndex, quizArray.length])

    const goToPrevious = () => {
        const isFirstSlide = currentIndex === 0;
        const newIndex = isFirstSlide ? quizArray.length -1 : currentIndex-1;
        setCurrentIndex(newIndex);
    };


    const goToNext = useCallback(() => {
        const isLastSlide = currentIndex === quizArray.length-1;
        const newIndex = isLastSlide ? 0 : currentIndex+1;
<<<<<<< Updated upstream
        setCurrentIndex(newIndex);
    };
=======
        goToIndex(newIndex);
    }, [currentIndex, quizArray]);
>>>>>>> Stashed changes

    const goToIndex = (index) => {
        setCurrentIndex(index);
    }
    
    const getSlideStylesWithBackground = (quizIndex) => ({
        ...slideStyles,
        backgroundImage: `url(${quizArray[quizIndex].thumbnailUrl})`,
    })

    const getSlideContainerStylesWithWidth = () => ({
        width: `${100 * quizArray.length}%`,
        transform: `translateX(${-(currentIndex * sliderContainerWidth)}px)`
    })

    const getSliderContainerWidth = () => {
        if (sliderContainerRef.current) {
            return sliderContainerRef.current.offsetWidth; // Get the actual width
        }
        return 738; // Default value if the ref is not available yet
    }

    useEffect(() => {
        // This effect will run when the component mounts and whenever the ref changes
        const containerWidth = getSliderContainerWidth();
        setSliderContainerWidth(containerWidth); // Set the actual width
        getSlideContainerStylesWithWidth(containerWidth);
        console.log('Slider container width:', containerWidth);
      }, [sliderContainerRef, currentIndex]);


    const testImageUrl = 'https://img.freepik.com/free-vector/404-error-with-landscape-concept-illustration_114360-7898.jpg?size=626&ext=jpg&ga=GA1.1.1687694167.1696291200&semt=ais';
    const slideStyles = {
        height: '100%',
        width: '100%',
        borderRadius: '20px',
        backgroundPosition: 'center',
        backgroundSize: 'cover',
        backgroundImage: `url(${quizArray.length!==0 ? quizArray[currentIndex].thumbnailUrl: testImageUrl})`,
    }
    
    return (
        <div className='slidercontainer' ref={sliderContainerRef}> 
            <div className='slideeffectcontainer' style={getSlideContainerStylesWithWidth()}>
                {quizArray.map((_, quizIndex) =>(
                    <div key = {quizIndex} style={getSlideStylesWithBackground(quizIndex)} ></div>
                ))}
            </div>
            <div className='leftarrow' onClick={goToPrevious}>🢀</div>
            <div className='rightarrow' onClick={goToNext}>🢂</div>
            <div className='dotcontainer'>
                {quizArray.map((quiz, quizIndex) => (
                    <div
                    key = {quizIndex} 
                    className='dotstyles'
                    onClick = {() => goToIndex(quizIndex)}
                    >
                        •
                    </div>
                    
                ))}
            </div>
            {
                quizArray.length!==0 ? (<div>Name: { quizArray[currentIndex].quizName} Popularity: {quizArray[currentIndex].popularity} Rating: {quizArray[currentIndex].rating} </div>) : <></>
            }
            </div>
    )
}