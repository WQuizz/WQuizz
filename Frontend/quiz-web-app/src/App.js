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


function App() {
  const [loggedIn, setLoggedIn] = useState(false);
  const [user, setUser] = useState(null);
  const cookies = new Cookies();

    const setLoggedInOnLoad = () =>{
      const jwtToken = cookies.get("jwt_authorization");
      console.log("Getting the token from cookies")
      if (jwtToken) {
        // If the cookie exists, consider the user as logged in
        console.log("cookie found, logging you in");
        setLoggedIn(true);
        if (user===null) {
          console.log("User is null, fetching user");
          fetchUserProfile(jwtToken, setUser);
        }
      }
    }

    useEffect(() => {
      // Check if the jwt_authentication cookie exists
      console.log("Loading page")
      setLoggedInOnLoad();
    }, []);

    useEffect(()=>{
        //Using this function on log in to fetch the user without reloading
        if (!loggedIn) {
          console.log("Logged out, setting user to null");
          setUser(null);
        }
        else{
          console.log("Logged in, fetching user");
          setLoggedInOnLoad();
        }
        console.log("LoggedIn and/or cookies changed");
    },[loggedIn, cookies])

    useEffect(()=>{
      console.log("Something changed about the user");
      console.log(user);
    },[user])

  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout loggedIn={loggedIn} logOut={logOut} cookies={cookies} setLoggedIn={setLoggedIn} userName={user?.userName}/>,
      errorElement: <Layout loggedIn={loggedIn} logOut={logOut} cookies={cookies} setLoggedIn={setLoggedIn} userName={user?.userName}/>,
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
          path: "/profile/edit/:userName",
          element: <EditProfilePage user={user} />
        },
        {
          path: "/profile/:userName",
          element: <ProfilePage user={user} />
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
