   M S B A M L   `   `   `  ����U  QGraphSharp.Controls, Version=1.0.7146.16055, Culture=neutral, PublicKeyToken=nullV>clr-namespace:GraphSharp.Controls;assembly=GraphSharp.ControlsGraphSharp.Controls  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   O KWPFExtensions, Version=1.0.3437.34043, Culture=neutral, PublicKeyToken=nullV;clr-namespace:WPFExtensions.Controls;assembly=WPFExtensionsWPFExtensions.Controls 5   	   T PSocialGraph.DesktopClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SocialGraph.DesktopClientSocialGraph.DesktopClient 5   	   *   $SocialGraph.DesktopClient.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   U
graphsharp>clr-namespace:GraphSharp.Controls;assembly=GraphSharp.Controls     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   Lzoom;clr-namespace:WPFExtensions.Controls;assembly=WPFExtensions     5   	   9local'clr-namespace:SocialGraph.DesktopClient     5   	   -   5          �Name$
  root��5   	    � Title$ Social Graph��5	   	   $	��800��5
   	   $	��800��5   	    � DataContext 5   	   ��  �� ElementName$
 root�� �� Path$ 	ViewModel� � 	Resources 5         demoTemplate �� DataType&   SocialGraph.DesktopClient.Vertex.  (System.Windows.Interactivity.Interaction   Triggers/  )System.Windows.Interactivity.EventTrigger   	EventName.  (System.Windows.Interactivity.TriggerBase	   Actions6  0System.Windows.Interactivity.InvokeCommandAction
   Command   CommandParameter �� Orientation �� Mode'   !GraphSharp.Controls.VertexControl �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding   Vertex J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color   Opacity   	Direction��%�  &	        '  P    7   �� 5   
   "  6,   .R�5      ��  5        5      $ MouseDoubleClick��6%   .	 5        
 60   �� $
 root��$ ViewModel.OnVertexClick� 5   0   �� $ Id�5      .��5      �� $ 
Horizontal=�6   $��5q�66   .+�5      �� ��6    �� $ Id�$ OneWay=�5      5      5      �� 5   
   "  6   .�5      ��  � �� 5      �� 5       "  6&   .R�5!      �� 
����ح�
�������$��2q�5#      $ 10,10,10,10��5$      # z��5%      ._�5&      �� #��z 6/   8��  5'   !    5)        5*   "   $ 2Q�63   $ 	LightGray��6B   $	 0.3Q�5+      $	 315Q�6+   5-      5.      50      51      52      .��54      � .+�55   
   (  "WPFExtensions.Controls.ZoomControl  ���	#fff5f5f5.��56      %	   GraphSharp.Controls.GraphLayout	  -   5         	 Name$ graphLayout��56   %   �
   �GraphSharp.Controls.GraphLayout`3[[System.Object, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[QuickGraph.IEdge`1[[System.Object, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], QuickGraph, Version=3.2.40122.0, Culture=neutral, PublicKeyToken=f3fb40175eec2af3],[QuickGraph.IBidirectionalGraph`2[[System.Object, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[QuickGraph.IEdge`1[[System.Object, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], QuickGraph, Version=3.2.40122.0, Culture=neutral, PublicKeyToken=f3fb40175eec2af3]], QuickGraph, Version=3.2.40122.0, Culture=neutral, PublicKeyToken=f3fb40175eec2af3]] 
  LayoutAlgorithmType$
 ISOM��58   %   " 
  OverlapRemovalAlgorithmType$	 FSA��59   %    
  HighlightAlgorithmType$ Simple��5:   %    
  Graph 57   %   �� $ GraphToVisualize�5:   %   5;      �� 5<   
   $��Bottom=�6   $��30��6/   .@�5=      �� ��6   �� $ OneWay=�$ 
StatusText�5>      5?      5@      