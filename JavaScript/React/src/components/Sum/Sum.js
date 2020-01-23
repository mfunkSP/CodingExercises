import React from "react";
import { Row, Col } from "reactstrap";
import "./Sum.css";

function Sum(props) {
  const calcInStock = () => {
    var sum = 0;
    if (props.products) {
      props.products.forEach(item => {
        sum += item.quantity;
      });
    }

    return sum;
  };

  return (
    <Row className="sumRow">
      <Col>Total of these items in stock: </Col>
      <Col>{calcInStock()}</Col>
    </Row>
  );
}

export default Sum;
