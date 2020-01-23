import React from "react";
import "./Filter.css";

function Filter(props) {
  return (
    <div className="filter-list">
      <input type="text" placeholder="Search" onChange={props.onFilter} />
    </div>
  );
}

export default Filter;
