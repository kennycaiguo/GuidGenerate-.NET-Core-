package #namespaceName#

import java.util.*;

public class #className# extends #parentClassName# {

#has#
		public Boolean has#propName#(){
			if(this.get#propName#() != null){
				return true;
			}
			else
			{
				return false;
			}
		}
    
#is#
		public Boolean is#propName#() {
        		return this.get#propName#();
    		}

#count#
    		public int count#propName#()
        	{
        	        int i = this.get#propName#().size();

            		return i;
        	}

#countMember#
    		public Boolean has#propName#Member()
        	{
        	        int i = this.get#propName#().size();

			if(i > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
        	}
	}
}
