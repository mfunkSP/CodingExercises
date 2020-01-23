import React from "react";
import "./List.css";
import { Grid } from "@material-ui/core";
import ListItem from "../ListItem/ListItem";
import HeaderComponent from "../HeaderComponet/HeaderComponent";

function List(props) {
  const items = props.products.map(item => {
    return (
      <Grid item xs={12} key={item.name}>
        <ListItem item={item} className="listItems" />
      </Grid>
    );
  });

  const columnHeaders = {
    name: "Product:",
    quantity: "In Stock:",
    location: "Department:"
  };

  return (
    <div className="gridContainer">
      <Grid container spacing={1}>
        <Grid item xs={12}>
          <HeaderComponent />
          <ListItem item={columnHeaders} />
        </Grid>
        {items}
      </Grid>
    </div>
  );
}

export default List;
