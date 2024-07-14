import { OperationTypes } from "../сalculator/consts/operation-types";

export const checkCalculatingExpression = (
  expression: string
) => {
  let x = /^[\d()+\-*\/\s]+$/;
  return x.test(expression);
};
