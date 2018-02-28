/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Beans;

/**
 *
 * @author Home
 */
import java.text.DateFormat;
import java.text.SimpleDateFormat;

import java.util.Date;

public class pay implements java.io.Serializable{
  
 private int amount_payed;
 private String  next_date;

 public pay(){}
    
 public int getAmount_payed() {
    return amount_payed;
 }

 public void setAmount_payed(int amount) {
    this.amount_payed = amount;
 }
  public String getNext_date() {
     return next_date;
 }

 public void setNext_date(String date)
 {
     this.next_date =date;
               
 }

 
}
