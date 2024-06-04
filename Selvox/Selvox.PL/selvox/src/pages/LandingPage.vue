<template>
<body>
    <header>
        <div class="menu">Selvox</div>
        <div class="logo"><img src="../assets/SelvoxLogo2.png" alt="selvox"></div>
        <button class="learn-price">Learn Price</button>
    </header>
    <main>
        <div class="content">
            <div class="text-container">
                <div class="text-section">
                    <h1>Stop feeling lost in your job search!  <span>Selvox</span> helps you discover your dream career by analyzing your psychological behavior and brain patterns.  Unlock your full potential and find a job that excites you. Get started today!</h1>
                    <button class="get-started">Get Started</button>
                    <br>
                    <a href="#" class="learn-more">Looking for startup jobs? Learn more here.</a>
                </div>
            </div>
            <div class="image-container">
                <img src="../assets/LP.png" alt="Phone Mockup">
            </div>
        </div>
    </main>
</body>
</template>

<style scoped>

span {
  color: #FDA1BA;
}

h1 {
  font-weight: 200;
}

body {
    font-family: 'Helvetica', sans-serif;
    margin: 0;
    background: #fcfcfc;
    color: #3A445D;
}

header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 20px;
}

.menu {
  font-size: 2em;
  font-weight: bold;
  color: #FFB7CA;
}

.logo {
  height: 5vh;
  width: 5vw;
}

.learn-price {
     --pink: #FFB7CA;
    font-size: 15px;
    padding: 0.7em 2.0em;
    letter-spacing: 0.06em;
    position: relative;
    font-family: inherit;
    border-radius: 0.6em;
    overflow: hidden;
    transition: all 0.3s;
    line-height: 1.4em;
    border: 2px solid var(--pink);
    color: var(--pink);
    box-shadow: inset 0 0 10px rgba(255, 183, 202, 0.4), 0 0 9px 3px rgba(255, 183, 202, 0.1);
}

main {
    display: flex;
    justify-content: center;
    margin: 0;
    align-items: center;
    height: calc(100vh - 60px);
}

.content {
    display: flex;
    justify-content: space-between;
    align-items: stretch;
    width: 80%;
    gap: 20px;
    flex-wrap: wrap;
    height: 90%;
}

.text-container {    
  display: flex;
    justify-content: center;
    align-items: center;
    padding: 20px;
    gap: 10px;
    flex: 1;
}

.image-container {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 20px;
    flex: 1;
}

.text-section {
    max-width: 80%;
}

.users {
    display: flex;
    align-items: center;
    margin-bottom: 20px;
}

.users img {
    width: 40px;
    height: 40px;
    border-radius: 50%;
    margin-right: 10px;
}

.users span {
    font-size: 1em;
}

h1 {
    font-size: 2em;
    margin-bottom: 20px;
}

.get-started {
    background: #d784b5;
    color: white;
    border: none;
    padding: 10px 20px;
    border-radius: 20px;
    cursor: pointer;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    margin-bottom: 20px;
}

.learn-more {
    color: #d784b5;
    text-decoration: none;
}

.image-container img {
    max-width: 100%;
    height: auto;
}
</style>