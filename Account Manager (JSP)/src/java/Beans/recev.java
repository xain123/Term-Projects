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

public class recev implements java.io.Serializable{
  
 private int amount_recev;
 private String  next_date;

 public recev(){}
    
 public int getAmount_recev() {
    return amount_recev;
 }

 public void setAmount_recev(int amount) {
    this.amount_recev = amount;
 }
  public String getNext_date() {
     return next_date;
 }

 public void setNext_date(String date)
 {
     this.next_date =date;
               
 }

 
}


