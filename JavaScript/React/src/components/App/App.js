import React, { useState, useEffect, useCallback } from "react";
import "./App.css";
import List from "../List/List";
import Filter from "../Filter/Filter";
import Sum from "../Sum/Sum";
import { getData } from "../../api/api";

function App() {
  const [allProducts, setAllProducts] = useState([]);
  const [filteredProducts, setFilteredProducts] = useState([]);

  const getProductData = useCallback(async () => {
    const res = await getData();
    setAllProducts(res);
    setFilteredProducts(res);
  }, []);

  useEffect(() => {
    getProductData();
  }, [getProductData]);

  const filterProducts = e => {
    var updatedList = allProducts;
    updatedList = updatedList.filter(item => {
      return (
        item.name.toLowerCase().search(e.target.value.toLowerCase()) !== -1
      );
    });

    setFilteredProducts(updatedList);
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>Coding Exercise</h1>
        <hr />
        <br />
        <Filter onFilter={filterProducts} />
        <List products={filteredProducts} />
        <br />
        <Sum products={filteredProducts} />
      </header>
    </div>
  );
}

export default App;
