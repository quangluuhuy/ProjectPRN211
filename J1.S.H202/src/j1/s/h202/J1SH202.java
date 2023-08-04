/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package j1.s.h202;

import java.util.Scanner;

/**
 *
 * @author admin
 */
public class J1SH202 {

    /**
     * @param args the command line arguments
     */
   public static void main(String[] args) {
         System.out.println("Enter string:");
        Scanner sc = new Scanner(System.in);
        String str = sc.nextLine().trim();
        if (!str.isEmpty()) {
            //nếu null thì thoát chương trình luôn|
            // khác null thì gọi đến  hàm printreverse
            printReverse(str);
        }
    }
    public static void printReverse(String str){
        String reverse = "";
        for (int i = str.length()-1; i >=0; i--) {
            reverse = reverse+str.charAt(i);
        }
        System.out.println(reverse);
    }
    
}
