// xtree internal header
using std::swap;
#define red Color::Red
#define black Color::Black
#ifndef XTREE
#define XTREE

enum class Color{ Red, Black }; // colors for link to parent

template< typename Ty >
struct TreeNode
{
   using NodePtr = TreeNode *;
   using value_type = Ty;

   NodePtr    left;   // left subtree, or smallest element if head
   NodePtr    parent; // parent, or root of tree if head
   NodePtr    right;  // right subtree, or largest element if head
   Color      color;  // Red or Black, Black if head
   bool       isNil;  // true only if head (also nil) node
   value_type myval;  // the stored value, unused if head
};

// CLASS TEMPLATE TreeVal
template< typename Ty >
class TreeVal
{
public:
   using NodePtr = TreeNode< Ty > *;

   using value_type = Ty;
   using size_type  = size_t;

   TreeVal()
      : myHead( new TreeNode< value_type > ),
        mySize( 0 )
   {
      myHead->left = myHead;
      myHead->parent = myHead;
      myHead->right = myHead;
      myHead->color = Color::Black;
      myHead->isNil = true;
   }

   ~TreeVal()
   {
      clear( myHead->parent );
      delete myHead;
   }

   // Removes all elements from the set object (which are destroyed)
   void clear( TreeNode< value_type > *node )
   {
      if( !node->isNil ) // node is not an external node
      {
         clear( node->left );
         clear( node->right );
         delete node;
      }
   }

   // rebalance for insertion
   void reBalance( TreeNode< value_type > *node )
   {  // node->parent cannot be the root

       NodePtr p = node->parent;
       NodePtr g = p->parent;
       NodePtr u = g->right == p ? g->left : g->right;
       if (p->isNil)
       {
           node->color = Color::Black;
           return;
       }

       if (p->color == Color::Black)
           return;

       if (u->color == Color::Red)
       {
           g->color = Color::Red;
           p->color = Color::Black;
           u->color = Color::Black;
           reBalance(g);
       }
       else if (g->left == p)
       {
           g->color = Color::Red;
           if (p->left == node)
           {
               p->color = Color::Black;
               LLRotation(p);
           }
           else if (p->right == node)
           {
               node->color = Color::Black;
               LRRotation(node);
           }
       }
       else if (g->right == p)
       {
           g->color = Color::Red;
           if (p->left == node)
           {
               node->color = Color::Black;
               RLRotation(node);
           }
           else if (p->right == node)
           {
               p->color = Color::Black;
               RRRotation(p);
           }
       }
   }

   // rotate right at g, where p = g->left and node = p->left
   //void set< Kty >::LLbRotation( TreeNode< value_type > *node )
   void LLRotation( TreeNode< value_type > *p )
   {
       /*NodePtr g = p->parent;
       NodePtr gp = g->parent;
       gp->isNil ? gp->parent = p : (gp->left == g ? gp->left = p : gp->right = p);
       g->parent = p;
       g->left = p->right;
       if(!p->right->isNil)//*****
           p->right->parent = g;
       p->right = g;
       p->parent = gp;*/
       NodePtr g = p->parent;
       NodePtr gp = g->parent;
       if (gp->isNil)
           gp->parent = p;
       else
           gp->left == g ? gp->left = p : gp->right = p;
       g->parent = p;
       g->left = p->right;
       if (!p->right->isNil)
           p->right->parent = g;
       p->right = g;
       p->parent = gp;
   }

   // LR rotation; p = g->left and node = p->right
   void LRRotation( TreeNode< value_type > *node )
   {
       RRRotation(node);
       LLRotation(node);
   }

   // RL rotation; p = g->right and node = p->left
   void RLRotation( TreeNode< value_type > *node )
   {
       LLRotation(node);
       RRRotation(node);
   }

   // rotate left at g, where p = g->right and node = p->right
   //void set< Kty >::RRbRotation( TreeNode< value_type > *node )
   void RRRotation( TreeNode< value_type > *p )
   {
       NodePtr g = p->parent, gp = g->parent;
       
       g->right = p->left;
       if (!p->left->isNil) p->left->parent = g;//ª`·N
       p->parent = gp;
       gp->isNil ? gp->parent = p : (gp->left == g ? gp->left = p : gp->right = p);
       p->left = g;
       g->parent = p;
       
   }

   // erase node provided that the degree of node is at most one
   void eraseDegreeOne( TreeNode< value_type > *node )
   {
       NodePtr parent = node->parent;
       NodePtr child = node->left->isNil ? node->right : node->left;

       if (parent->isNil && node->color == Color::Black && child->color == Color::Black)
       {
           child->parent = myHead;
           myHead->parent = child;
           delete node;
           --mySize;
           return;
       }

       parent->left == node ? parent->left = child : parent->right = child;
       if (!child->isNil)
           child->parent = parent;

       if (!parent->isNil && node->color == Color::Black && child->color == Color::Black)
           fixUp(child, parent);

       if (node->color == Color::Black && child->color == Color::Red)
           child->color = Color::Black;

       delete node;
       --mySize;
   }

   // rebalance for deletion
   void fixUp( TreeNode< value_type > *N, TreeNode< value_type > *P )
   {
       NodePtr S = N == P->left ? P->right : P->left;

       if (S->color == Color::Red && N == P->left)//case1.1
       {
           S->color = P->color;
           P->color = Color::Red;
           RRRotation(S);
       }
       if (S->color == Color::Red && N == P->right)//case1.2
       {
           S->color = P->color;
           P->color = Color::Red;
           LLRotation(S);
       }

       S = N == P->left ? P->right : P->left;

       if (S->color == Color::Black && S->right->color == Color::Black && N == P->left && S->left->color == Color::Red)//case3.1
       {
           S->color = Color::Red;
           S->left->color = Color::Black;
           LLRotation(S->left);
       }
       if (S->color == Color::Black && S->left->color == Color::Black && N == P->right && S->right->color == Color::Red)//case3.2
       {
           S->color = Color::Red;
           S->right->color = Color::Black;
           RRRotation(S->right);
       }

       S = N == P->left ? P->right : P->left;

       if (S->color == Color::Black && S->right->color == Color::Red && N == P->left)//case2.1
       {
           S->color = P->color;
           P->color = Color::Black;
           S->right->color = Color::Black;
           RRRotation(S);
           return;
       }
       if (S->color == Color::Black && S->left->color == Color::Red && N == P->right)//case2.2
       {
           S->color = P->color;
           P->color = Color::Black;
           S->left->color = Color::Black;
           LLRotation(S);
           return;
       }
       
       if (S->color == Color::Black && S->right->color == Color::Black && S->left->color == Color::Black && P->color == Color::Red)//case4
       {
           S->color = Color::Red;
           P->color = Color::Black;
           return;
       }

       if (S->color == Color::Black && S->right->color == Color::Black && S->left->color == Color::Black && P->color == Color::Black)//case5
       {
           S->color = Color::Red;
           fixUp(P, P->parent);
       }
   }
/*
   // preorder traversal and inorder traversal
   void twoTraversals()
   {
      cout << "Preorder sequence:\n";
      preorder( myHead->parent );

      cout << "\nInorder sequence:\n";
      inorder( myHead->parent );
      cout << endl;
   }

   // preorder traversal
   void preorder( TreeNode< value_type > *node )
   {
      if( node != myHead )
      {
         cout << setw( 5 ) << node->myval << ( node->color == Color::Red ? "R" : "B" );
         preorder( node->left );
         preorder( node->right );
      }
   }

   // inorder traversal
   void inorder( TreeNode< value_type > *node )
   {
      if( node != myHead )
      {
         inorder( node->left );
         cout << setw( 5 ) << node->myval << ( node->color == Color::Red ? "R" : "B" );
         inorder( node->right );
      }
   }
*/
   NodePtr myHead;   // pointer to head node
   size_type mySize; // number of elements
};

// CLASS TEMPLATE Tree
template< typename Traits >
class Tree // ordered red-black tree for map/multimap/set/multiset
{
public:
   using value_type = typename Traits::value_type;

protected:
   using ScaryVal = TreeVal< value_type >;

public:
   using key_type      = typename Traits::key_type;
   using key_compare   = typename Traits::key_compare;

   using size_type       = size_t;

   Tree( const key_compare &parg )
      : keyCompare( parg ),
        scaryVal()
   {
   }

   ~Tree()
   {
   }

   // Extends the container by inserting a new element,
   // effectively increasing the container size by one.
   void insert( const value_type &val )
   {
       TreeNode<value_type>* head = scaryVal.myHead;
       TreeNode<value_type>* current = head;
       TreeNode<value_type>* child = head->parent;

       while (!child->isNil && current->myval != val)
       {
           current = child;
           keyCompare(val, current->myval) ? child = child->left : child = child->right;
       }
       if (val == current->myval)
           return;

       auto node = new TreeNode<value_type>{ head,current,head,Color::Red,false,val };
       ++scaryVal.mySize;//*****
       if (current == head)
       {
           node->color = Color::Black;
           head->parent = node;
           head->right = node;
           head->left = node;
       }
       else
       {
           keyCompare(val, current->myval) ? current->left = node : current->right = node;
           if (keyCompare(val, head->left->myval))
               head->left = node;
           else if (keyCompare(head->right->myval, val))
               head->right = node;
       }

       scaryVal.reBalance(node);
   }

   // Removes from the set container a single element whose value is val
   // This effectively reduces the container size by one, which are destroyed.
   // Returns the number of elements erased.
   size_type erase( const key_type &val )
   {
       TreeNode<value_type>* head = scaryVal.myHead;
       TreeNode<value_type>* node = head->parent;

       while (!node->isNil && node->myval != val)
           node = keyCompare(val, node->myval) ? node->left : node->right;
       if (node->isNil && head->myval != val)
           return 0;

       if (!node->left->isNil && !node->right->isNil)
       {
           TreeNode<value_type>* newNode = node->right;
           while (!newNode->left->isNil)
               newNode = newNode->left;
           node->myval = newNode->myval;
           node = newNode;
       }

       if (head->left == node)
           head->left = node->parent;
       else if (head->right == node)
           head->right = node->parent;

       scaryVal.eraseDegreeOne(node);
       return 1;
   }

private:
   key_compare keyCompare;
   ScaryVal scaryVal;
};

#endif // XTREE