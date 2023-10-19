import React, { useState, useEffect } from 'react';
import ReactDOM from 'react-dom/client';
import reportWebVitals from './reportWebVitals';
import {BrowserRouter, createBrowserRouter, RouterProvider, Route} from 'react-router-dom'
import Cookies from 'universal-cookie';
import { logOut, fetchLoggedInUserProfile as fetchUserProfile } from './Services/userServices';

import NavigationBar from './Components/NavigationBar';
import DummyPage from './Pages/DummyPage.jsx'
import CategoriesPage from './Pages/CategoriesPage';
import CategoryPage from './Pages/CategoryPage';
import Layout from './Pages/Layout';
import RegisterPage from './Pages/RegisterPage';
import LoginPage from './Pages/LoginPage';
import QuizPage from './Pages/QuizPage';
import ProfilePage from './Pages/ProfilePage';
import EditProfilePage from './Pages/EditProfilePage';
import jwtDecode from 'jwt-decode';


function App() {
  const [loggedIn, setLoggedIn] = useState(false);
  const [userName, setUserName] = useState(null);
  const cookies = new Cookies();

    const setLoggedInOnLoad = () =>{
      const jwtToken = cookies.get("jwt_authorization");
      if (jwtToken) {
        // If the cookie exists, consider the user as logged in
        setLoggedIn(true);
        fetchUserProfile(jwtToken, setUserName);
        setUserName(jwtDecode(jwtToken)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"])
      }
    }

    useEffect(() => {
      // Check if the jwt_authentication cookie exists
      setLoggedInOnLoad();
    }, []);

    useEffect(()=>{
        //Using this function on log in to fetch the user without reloading
        if (loggedIn) {
          setLoggedInOnLoad();
        }

    },[loggedIn, cookies])

  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout loggedIn={loggedIn} logOut={logOut} cookies={cookies} setLoggedIn={setLoggedIn} userName={userName} setUserName={setUserName}/>,
      errorElement: <Layout loggedIn={loggedIn} logOut={logOut} cookies={cookies} setLoggedIn={setLoggedIn} userName={userName} setUserName={setUserName}/>,
      children: [
        {
          path: "/",
          element: <DummyPage />,
        },
        {
          path: "/categories",
          element: <CategoriesPage />
        },
        {
          path: "/registration",
          element: <RegisterPage loggedIn={loggedIn}/>
        },
        {
          path: "/login",
          element: <LoginPage setLoggedIn={setLoggedIn} loggedIn={loggedIn}/>
        },
        {
          path: "/playQuiz/:quizName",
          element: <QuizPage />
        },
        {
          path: "/category/:categoryName",
          element: <CategoryPage />
        },
        {
          path: "/profile/edit/:profileName",
          element: <EditProfilePage userName={userName}/>
        },
        {
          path: "/profile/:profileName",
          element: <ProfilePage userName={userName}/>
        },
      ]
    }
  ]);
  

  return(
    <React.StrictMode>
      <RouterProvider router={router} />
    </React.StrictMode>
  );
}
  
export default App;
